using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        private int tickMultiplier = 1;
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
        public async Task Start()
        {
            #region Subscribers
            StartClock += StartTicker;

            ticker.Tiktok += time.OnCalculateCurrentTime;
            ticker.Tiktok += EveryTickReport;
            ticker.Tiktok += ChangeGenderOnExArea;
            ticker.Tiktok += MoveToCageFromExArea;
            ticker.Tiktok += MoveToExerciseArea;


            #endregion Subscribers

            //Asking user for month and day, and days to simulate
            daysToSimulate = frontend.GetAmountOfDays();
            speed = frontend.GetSpeed();
            remainingDaysToSimulate = daysToSimulate;
            month = frontend.GetMonth();
            day = frontend.GetDay();


            //Methods
            await Task.Run(() => ClearAllLogsAndActivities());
            await Task.Run(() => time.CalculateStartTime(month, day));
            await Task.Run(() => AddHamsters());

            //Invoking the event/simulation to start     
            await Task.Run(() => StartClock?.Invoke(this, EventArgs.Empty));

        }

        /// <summary>
        /// Runs the event "ticking" which has numerous subs, asynchronously
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void StartTicker(object sender, EventArgs e)
        {
            while (ticker.tick <= remainingDaysToSimulate * 100 + 1)
            {
                if (time.CurrentTime == time.StartTime.AddHours(10) && remainingDaysToSimulate > 1)
                {

                    string dailyReport = await Task.Run(() => DailyReport());
                    await Task.Run(() => frontend.PrintOutDailyReport(dailyReport));

                    remainingDaysToSimulate--;
                    ticker.tick = 0;
                    tickMultiplier = 0;

                    await Task.Run(() => RemoveHamsters());
                    time.StartTime = time.CurrentTime.AddHours(14);

                    await Task.Run(() => AddHamsters());
                    await Task.Run(() => ticker.Ticking(speed));


                }
                else if (time.CurrentTime == time.StartTime.AddHours(10) && remainingDaysToSimulate == 1)
                {

                    string dailyReport = await Task.Run(() => DailyReport());
                    await Task.Run(() => frontend.PrintOutDailyReport(dailyReport));
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
        /// Clears all ActivityLoggers and Activities in the database.
        /// </summary>
        private void ClearAllLogsAndActivities()
        {
            if (hdb.ActivityLoggers != null)
            {
                var allActivities = hdb.Activities.Select(c => c).ToList();
                var allLogs = hdb.ActivityLoggers.Select(c => c).ToList();

                foreach (var row in allActivities)
                {
                    hdb.Activities.Remove(row);
                }
                foreach (var row in allLogs)
                {
                    hdb.ActivityLoggers.Remove(row);
                }
                hdb.SaveChanges();
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
            var femaleList = filledListOfHamsters.Select(c => c).Where(c => c.Gender == Gender.Female).OrderBy(c => c.Name).ToList();

            //fills a list with all the male-hamsters
            var maleList = filledListOfHamsters.Select(c => c).Where(c => c.Gender == Gender.Male).OrderBy(c => c.Name).ToList();

            //Fills a array of all the cages stored in the database
            Cage[] cage = hdb.Cages.ToArray();

            for (int i = 0; i < cage.Length; i++)
            {
                while (!cage[i].IsFull)
                {
                    if (cage[i].Gender == Gender.Male)
                    {
                        cage[i].hamsterList.Add(maleList[maleCounter]);

                        var activity = new Activity { ActivityType = Activities.CheckIn, TimeOfStart = time.StartTime };
                        var log = new ActivityLogger { Hamster = maleList[maleCounter], Date = time.DateString, Activities = new List<Activity>() };
                        log.Activities.Add(activity);

                        if (maleList[maleCounter].ActivityLogger == null)
                        {
                            maleList[maleCounter].ActivityLogger = new List<ActivityLogger>();
                        }
                        maleList[maleCounter].ActivityLogger.Add(log);

                        cage[i].hamsterList[statsCounter].OldCageId = null;
                        cage[i].hamsterList[statsCounter].TimeOfLastExercise = null;
                        cage[i].hamsterList[statsCounter].CageId = cage[i].Id;
                        cage[i].hamsterList[statsCounter].CheckInTime = time.StartTime;
                        cage[i].hamsterList[statsCounter].CurrentActivity = "In cage";
                        maleCounter++;
                        statsCounter++;

                    }

                    else if (cage[i].Gender == Gender.Female)
                    {
                        cage[i].hamsterList.Add(femaleList[femaleCounter]);

                        var activity = new Activity { ActivityType = Activities.CheckIn, TimeOfStart = time.StartTime };
                        var log = new ActivityLogger { Hamster = femaleList[femaleCounter], Date = time.DateString, Activities = new List<Activity>() };
                        log.Activities.Add(activity);

                        if (femaleList[femaleCounter].ActivityLogger == null)
                        {
                            femaleList[femaleCounter].ActivityLogger = new List<ActivityLogger>();
                        }
                        femaleList[femaleCounter].ActivityLogger.Add(log);

                        cage[i].hamsterList[statsCounter].OldCageId = null;
                        cage[i].hamsterList[statsCounter].TimeOfLastExercise = null;
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
        private void RemoveHamsters()
        {

            int counter = 0;

            Cage[] cage = hdb.Cages.ToArray();

            for (int i = 0; i < cage.Length; i++)
            {
                while (cage[i].hamsterList.Count != 0)
                {
                    if (cage[i].Gender == Gender.Male)
                    {

                        //adding new activity and set the endTime of the previous activity.
                        var activity = new Activity { ActivityType = Activities.CheckOut, TimeOfStart = time.CurrentTime };

                        var log = hdb.ActivityLoggers
                            .Select(c => c)
                            .Where(c => c.HamsterId == cage[i].hamsterList[counter].Id)
                            .Where(c => c.Date == time.DateString)
                            .First();

                        activity.ActivityLogger = log;
                        log.Activities.Add(activity);

                        var endTimeOfPreviousActivity = log.Activities
                            .Select(c => c)
                            .Where(c => c.ActivityType == Activities.DayCage)
                            .OrderBy(c => c.TimeOfStart)
                            .Last();

                        endTimeOfPreviousActivity.TimeOfEnd = time.CurrentTime;

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
                        //adding new activity and set the endTime of the previous activity.
                        var activity = new Activity { ActivityType = Activities.CheckOut, TimeOfStart = time.CurrentTime };

                        var log = hdb.ActivityLoggers
                            .Select(c => c)
                            .Where(c => c.HamsterId == cage[i].hamsterList[counter].Id)
                            .Where(c => c.Date == time.DateString)
                            .First();

                        activity.ActivityLogger = log;
                        log.Activities.Add(activity);

                        var endTimeOfPreviousActivity = log.Activities
                            .Select(c => c)
                            .Where(c => c.ActivityType == Activities.DayCage)
                            .OrderBy(c => c.TimeOfStart)
                            .Last();

                        endTimeOfPreviousActivity.TimeOfEnd = time.CurrentTime;

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
        /// changes the gender for the ExerciseArea every 30 ticks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeGenderOnExArea(object sender, EventArgs e)
        {
            var exArea = hdb.ExerciseAreas.ToArray().First();

            if (time.CurrentTime == time.StartTime || time.CurrentTime == time.StartTime.AddHours(6))
            {
                exArea.Gender = Gender.Male;
            }
            else if (time.CurrentTime == time.StartTime.AddHours(3) || time.CurrentTime == time.StartTime.AddHours(9))
            {
                exArea.Gender = Gender.Female;
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Moves hamsters to the ExerciseArea every 10 ticks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if (!exArea.IsFull && time.CurrentTime != time.StartTime.AddHours(10))
                {
                    if (exArea.Gender == Gender.Male && orderedHamsters[i].Gender == Gender.Male)
                    {

                        //adding hamster to exArea
                        exArea.hamsterList.Add(orderedHamsters[i]);

                        //Adding activity
                        var activity = new Activity { ActivityType = Activities.Exercise, TimeOfStart = time.CurrentTime };

                        var log = hdb.ActivityLoggers
                            .Select(c => c)
                            .Where(c => c.HamsterId == orderedHamsters[i].Id)
                            .Where(c => c.Date == time.DateString)
                            .First();

                        activity.ActivityLogger = log;
                        log.Activities.Add(activity);

                        if (log.Activities.Count > 2)
                        {
                            var endTimeOfPreviousActivity = log.Activities
                                .Select(c => c)
                                .Where(c => c.ActivityType == Activities.DayCage)
                                .OrderBy(c => c.TimeOfStart)
                                .Last();

                            endTimeOfPreviousActivity.TimeOfEnd = time.CurrentTime;
                        }
                        else
                        {
                            var endTimeOfPreviousActivity = log.Activities
                                .Select(c => c)
                                .Where(c => c.ActivityType == Activities.CheckIn)
                                .First();

                            endTimeOfPreviousActivity.TimeOfEnd = time.CurrentTime;
                        }


                        //Setting props
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
                        //adding hamster to ExArea
                        exArea.hamsterList.Add(orderedHamsters[i]);

                        //Adding activity
                        var activity = new Activity { ActivityType = Activities.Exercise, TimeOfStart = time.CurrentTime };

                        var log = hdb.ActivityLoggers
                        .Select(c => c)
                        .Where(c => c.HamsterId == orderedHamsters[i].Id)
                        .Where(c => c.Date == time.DateString)
                        .First();

                        activity.ActivityLogger = log;
                        log.Activities.Add(activity);

                        if (log.Activities.Count > 2)
                        {
                            var endTimeOfPreviousActivity = log.Activities
                                .Select(c => c)
                                .Where(c => c.ActivityType == Activities.DayCage)
                                .OrderBy(c => c.TimeOfStart)
                                .Last();

                            endTimeOfPreviousActivity.TimeOfEnd = time.CurrentTime;
                        }
                        else
                        {
                            var endTimeOfPreviousActivity = log.Activities
                                .Select(c => c)
                                .Where(c => c.ActivityType == Activities.CheckIn)
                                .First();

                            endTimeOfPreviousActivity.TimeOfEnd = time.CurrentTime;
                        }

                        //Setting props
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
        /// Moves the hamsters from ExerciseArea back to the cages every 
        /// 10 ticks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveToCageFromExArea(object sender, EventArgs e)
        {
            if (time.CurrentTime == time.StartTime.AddHours(tickMultiplier))
            {
                tickMultiplier += 1;

                var cage = hdb.Cages.ToArray();
                var exArea = hdb.ExerciseAreas.ToArray().First();
                var hamList = exArea.hamsterList.ToList();
                var hamsters = new List<Hamster>();

                foreach (var hamster in hamList)
                {
                    //Adding to temporary list
                    hamsters.Add(hamster);

                    //adding new activity and set the endTime of the previous activity.
                    var activity = new Activity { ActivityType = Activities.DayCage, TimeOfStart = time.CurrentTime };

                    var log = hdb.ActivityLoggers
                        .Select(c => c)
                        .Where(c => c.HamsterId == hamster.Id)
                        .Where(c => c.Date == time.DateString)
                        .First();

                    activity.ActivityLogger = log;
                    log.Activities.Add(activity);

                    var endTimeOfPreviousActivity = log.Activities
                        .Select(c => c)
                        .Where(c => c.ActivityType == Activities.Exercise)
                        .OrderBy(c => c.TimeOfStart)
                        .Last();

                    endTimeOfPreviousActivity.TimeOfEnd = time.CurrentTime;

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

        /// <summary>
        /// Info to print every tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void EveryTickReport(object sender, EventArgs e)
        {
            int AmountOfHamsInExerciseArea = 0;
            int cageCounter = 1;

            var exArea = hdb.ExerciseAreas.ToArray();
            var cage = hdb.Cages.Select(c => c.hamsterList).ToArray();
            var gender = hdb.ExerciseAreas.Select(c => c.Gender).First();

            for (int i = 0; i < exArea.Length; i++)
            {
                AmountOfHamsInExerciseArea += exArea[i].hamsterList.Count();

            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Days to simulate : {daysToSimulate}");
            sb.AppendLine($"Remaining days to simulate : {remainingDaysToSimulate}");
            sb.AppendLine($"Tick : {ticker.tick}");
            sb.AppendLine($"CurrentTime : {time.CurrentTime}");
            cage.Select(c => c.Count)
                .ToList()
                .ForEach(c => sb.AppendLine($"Amount Of Hamsters In Cage: {cageCounter++} = {c}"));

            sb.AppendLine($"Amount Of Hamsters and Current Gender Exercising : {AmountOfHamsInExerciseArea} {gender}s");

            string tickReport = sb.ToString();
            await Task.Run(() => frontend.PrintOutDailyReport(tickReport));

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
