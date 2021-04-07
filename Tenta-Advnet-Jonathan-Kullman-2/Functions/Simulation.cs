using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    public class Simulation
    {
        private EventHandler StartClock;

        private Ticker ticker;
        private Frontend frontend;
        private Time time;
        private HamsterDbContext hdb;

        private int tickMultiplier;
        private int month;
        private int day;
        internal static int remainingDaysToSimulate;
        private int daysToSimulate;
        private int speed;

        public Simulation()
        {
            ticker = Ticker.GetInstance();
            time = new Time();
            frontend = new Frontend();
            hdb = new HamsterDbContext();
        }

        /// <summary>
        /// Method: Runs when the program starts.
        /// </summary>
        public void Start()
        {
            #region Subscribers

            StartClock += StartTicker;

            ticker.Tiktok += time.OnCalculateCurrentTime;
            ticker.Tiktok += Testshit;
            ticker.Tiktok += ChangeGenderOnExArea;
            ticker.Tiktok += MoveToExerciseArea;
            ticker.Tiktok += MoveToCageFromExArea;


            #endregion Subscribers

            //Asking user for month and day, and days to simulate
            daysToSimulate = frontend.GetAmountOfDays();
            speed = frontend.GetSpeed();
            remainingDaysToSimulate = daysToSimulate;
            month = frontend.GetMonth();
            day = frontend.GetDay();


            //Methods
            time.CalculateStartTime(month, day);
            AddHamsters();

            //Invoking the event/simulation to start     
            StartClock?.Invoke(this, EventArgs.Empty);

        }

        private void MoveToCageFromExArea(object sender, EventArgs e)
        {
            if (ticker.tick == 9 || ticker.tick == 9 + tickMultiplier)
            {
                tickMultiplier += 10;

                var cage = hdb.Cages.ToArray();
                var exArea = hdb.ExerciseAreas.ToArray().First();
                var hamList = exArea.hamsterList.ToList();
                var hamsters = new List<Hamster>();

                foreach (var hamster in hamList)
                {
                    hamsters.Add(hamster);
                    exArea.hamsterList.Remove(hamster);
                    hamster.TimeOfLastExercise = time.CurrentTime;
                    
                    for (int i = 0; i < cage.Length; i++)
                    {

                        if (cage[i].Id == hamster.OldCageId)
                        {
                            cage[i].hamsterList.Add(hamster);
                            hamster.CageId = cage[i].Id;
                            hamster.OldCageId = null;
                            hamster.CurrentActivity = "In cage";
                            hamster.ExerciseAreaId = null;

                        }

                    }
                    hdb.SaveChanges();
                }



   
            }
        }

        private void ChangeGenderOnExArea(object sender, EventArgs e)
        {
            var exArea = hdb.ExerciseAreas.ToArray().First();

            if (ticker.tick == 0 || ticker.tick == 60)
            {
                exArea.Gender = Gender.Male;
            }
            else if (ticker.tick == 30 || ticker.tick == 90)
            {
                exArea.Gender = Gender.Female;
            }
            else
            {
                return;
            }
        }

        private void MoveToExerciseArea(object sender, EventArgs e)
        {
            var hamsters = new List<Hamster>();
            var exArea = hdb.ExerciseAreas.ToArray().First();
            var cage = hdb.Cages.ToArray();

            foreach (var item in hdb.Cages)
            {
                for (int i = 0; i < item.hamsterList.Count; i++)
                {
                    hamsters.Add(item.hamsterList[i]);
                }
            }
             
            var orderedHamsters = hamsters.Select(c => c).OrderBy(c => c.TimeOfLastExercise).ToList();

            for (int i = 0; i < orderedHamsters.Count; i++)
            {
                if (!exArea.IsFull)
                {
                    if (exArea.Gender == Gender.Male && orderedHamsters[i].Gender == Gender.Male)
                    {
                        exArea.hamsterList.Add(orderedHamsters[i]);
                        orderedHamsters[i].OldCageId = orderedHamsters[i].CageId;
                        orderedHamsters[i].CageId = null;
                        orderedHamsters[i].CurrentActivity = "Exercising";
                        orderedHamsters[i].ExerciseAreaId = 1;

                        for (int j = 0; j < cage.Length; j++)
                        {
                            if (cage[j].hamsterList.Contains(orderedHamsters[i]))
                            {
                                cage[j].hamsterList.Remove(orderedHamsters[i]);
                            }
                        }
                    }
                    else if (exArea.Gender == Gender.Female && orderedHamsters[i].Gender == Gender.Female)
                    {
                        exArea.hamsterList.Add(orderedHamsters[i]);
                        orderedHamsters[i].OldCageId = orderedHamsters[i].CageId;
                        orderedHamsters[i].CageId = null;
                        orderedHamsters[i].CurrentActivity = "Exercising";
                        orderedHamsters[i].ExerciseAreaId = 1;

                        for (int j = 0; j < cage.Length; j++)
                        {
                            if (cage[j].hamsterList.Contains(orderedHamsters[i]))
                            {
                                cage[j].hamsterList.Remove(orderedHamsters[i]);
                            }
                        }
                    }
                }
                hdb.SaveChanges();
            }
          
        }

        /// <summary>
        /// Info to print every tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Testshit(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Days to simulate: {daysToSimulate}");
            sb.AppendLine($"Remaining days to simulate: {remainingDaysToSimulate}");
            sb.AppendLine($"Tick: {ticker.tick}");
            sb.AppendLine($"StartTime = {time.StartTime}");
            sb.AppendLine($"CurrentTime = {time.CurrentTime}");
            Console.WriteLine(sb.ToString());


        }

        /// <summary>
        /// Runs the event "ticking" which has numerous subs, asynchronously
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void StartTicker(object sender, EventArgs e)
        {
            while (ticker.tick <= remainingDaysToSimulate * 100)
            {
                if (ticker.tick == 101 && remainingDaysToSimulate > 1)
                {

                    string dailyReport = await Task.Run(() => DailyReport());
                    await Task.Run(() => frontend.PrintDailyReport(dailyReport));

                    remainingDaysToSimulate--;
                    time.StartTime = time.CurrentTime.AddHours(14);
                    ticker.tick = 0;

                    await Task.Run(() => RemoveHamsters());
                    
                    AddHamsters();

                    await Task.Run(() => ticker.Ticking(speed));

            
                }
                else if (ticker.tick == 100 && remainingDaysToSimulate == 1)
                {

                    string dailyReport = await Task.Run(() => DailyReport());
                    await Task.Run(() => frontend.PrintDailyReport(dailyReport));
                    await Task.Run(() => RemoveHamsters());
                    break;
                }
                else
                {
                    //the rest of the 99 ticks after the first day or the first 100 days
                    await Task.Run(() => ticker.Ticking(speed));

                }


            }
            return;

        }

        /// <summary>
        /// Adds all the 30 hamsters to their cages
        /// </summary>
        private void AddHamsters()
        {
            int maleCounter = 0;
            int femaleCounter = 0;
            int statsCounter = 0;
            //string activity = "Check in";

            //Fills a list of all the hamsters stored in the database
            var filledListOfHamsters = hdb.Hamsters.ToList();

            //Fills a list with all the female-hamsters
            var femaleList = filledListOfHamsters.Select(c => c).Where(c => c.Gender == Gender.Female).ToList();

            //fills a list with all the male-hamsters
            var maleList = filledListOfHamsters.Select(c => c).Where(c => c.Gender == Gender.Male).ToList();

            //Fills a array of all the cages stored in the database
            Cage[] cage = hdb.Cages.ToArray();

            for (int i = 0; i < cage.Length; i++)
            {
                while (!cage[i].IsFull)
                {
                    if (cage[i].Gender == Gender.Male)
                    {
                        cage[i].hamsterList.Add(maleList[maleCounter]);
                        cage[i].hamsterList[statsCounter].CageId = cage[i].Id;
                        cage[i].hamsterList[statsCounter].CheckInTime = time.StartTime;                    
                        cage[i].hamsterList[statsCounter].CurrentActivity = "In cage";                    
                        maleCounter++;
                        statsCounter++;
                    }
                    else if (cage[i].Gender == Gender.Female)
                    {
                        cage[i].hamsterList.Add(femaleList[femaleCounter]);
                        cage[i].hamsterList[statsCounter].CageId = cage[i].Id;
                        cage[i].hamsterList[statsCounter].CheckInTime = time.StartTime;
                        cage[i].hamsterList[statsCounter].CurrentActivity = "In cage";

                        femaleCounter++;
                        statsCounter++;
                    }

                }
                statsCounter = 0;
                hdb.SaveChanges();
            }

            

        } 

        /// <summary>
        /// Removes all the hamsters every 100 Ticks from the cages (return to their home).
        /// </summary>
        /// <returns></returns>
        private async Task RemoveHamsters()
        {
            await Task.Delay(100);

            int counter = 0;

            Cage[] cage = hdb.Cages.ToArray();

            for (int i = 0; i < cage.Length; i++)
            {
                while (cage[i].hamsterList.Count != 0)
                {
                    if (cage[i].Gender == Gender.Male)
                    {
                        cage[i].hamsterList[counter].CageId = null;
                        cage[i].hamsterList[counter].OldCageId = null;
                        cage[i].hamsterList[counter].ExerciseAreaId = null;
                        cage[i].hamsterList[counter].CheckInTime = null;
                        cage[i].hamsterList[counter].CurrentActivity = "Home";    
                        cage[i].hamsterList[counter].TimeOfLastExercise = null;                          
                        cage[i].hamsterList.Remove(cage[i].hamsterList[counter]);
                    }
                    else if (cage[i].Gender == Gender.Female)
                    {
                        cage[i].hamsterList[counter].CageId = null;
                        cage[i].hamsterList[counter].OldCageId = null;
                        cage[i].hamsterList[counter].ExerciseAreaId = null;
                        cage[i].hamsterList[counter].CheckInTime = null;
                        cage[i].hamsterList[counter].CurrentActivity = "Home";
                        cage[i].hamsterList[counter].TimeOfLastExercise = null;
                        cage[i].hamsterList.Remove(cage[i].hamsterList[counter]);
                    }
                }

                hdb.SaveChanges();
            }
        }     
        
        /// <summary>
        /// Builds the DailyReport-String and returns it.
        /// </summary>
        /// <returns></returns>
        private string DailyReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hamster in hdb.Hamsters)
            {
                sb.AppendLine($"\tName: {hamster.Name.PadLeft(5).PadRight(15)} " +
               $"| Gender: {hamster.OwnerId.ToString().PadLeft(2).PadRight(5)} | " +
               $"Last exercise: {hamster.Id.ToString().PadLeft(5).PadRight(15)}");
            }
            
          
            return sb.ToString();
        }
    }
}
