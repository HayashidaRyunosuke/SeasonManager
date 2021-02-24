using System;
using JetBrains.Annotations;
using UnityEngine;

public class SeasonManager : MonoBehaviour
{

    #region Singlton

    private static SeasonManager instance;

    public static SeasonManager Instance
    {
        get
        {
            if (!instance) instance = FindObjectOfType<SeasonManager>();
            return instance;
        }
    }

    #endregion
    
    [SerializeField]
    public bool isSimulateSeason = false;

    [SerializeField]
    private Date simulateDate;

    public bool setSeasonStart = false;
    
    [SerializeField] 
    private Date springStart;
    
    [SerializeField] 
    private Date summerStart;

    [SerializeField]
    private Date fallStart;

    [SerializeField]
    private Date winterStart;

    [Serializable]
    private class Date
    {
        public int month;
        public int day;

        public static Date SPRING_START
        {
            get
            {
                return  new Date()
                   {
                       month = 3,
                       day = 21
                   };
            }
        }

        public static Date SUMMER_START {
            get
            {
                return new Date()
                    {
                        month = 6,
                        day = 21
                    };
            }
        }

        public static Date FALL_START
        {
            get
            {
                return new Date()
                    {
                        month = 9,
                        day = 23
                    };
            }
        }

        public static Date WINTER_START
        {
            get
            {
                return new Date()
                   {
                       month = 12,
                       day = 22
                   };
            }
        } 

        public bool IsBeyondToday
        {
            get
            {
                DateTime now = DateTime.Now;
                Date today = new Date()
                {
                    month = now.Month,
                    day = now.Day
                };
                return this >= today;
            }   
        }

        #region Operators
        public static bool operator >(Date a,Date b)
        {
            if (a.month == b.month) return a.day > b.day;
            return a.month > b.month;
        }
        
        public static bool operator <(Date a,Date b)
        {
            if (a.month == b.month) return a.day < b.day;
            return a.month < b.month;
        }

        public static bool operator >=(Date a,Date b)
        {
            if (a.month == b.month) return a.day >= b.day;
            return a.month >= b.month;
        }
        
        public static bool operator <=(Date a,Date b)
        {
            if (a.month == b.month) return a.day <= b.day;
            return a.month <= b.month;
        }
        #endregion

    }
    
    public enum Season
    {
        SPRING,SUMMER,FALL,WINTER
    }
    
    public Season CURRENT_SEASON
    {
        get
        {
            Date ws = setSeasonStart ? winterStart : Date.WINTER_START;
            Date fs = setSeasonStart ? fallStart : Date.FALL_START;
            Date ss = setSeasonStart ? summerStart : Date.SUMMER_START;
            Date sps = setSeasonStart ? springStart : Date.SPRING_START;
            
            if (isSimulateSeason)
            {
                if (simulateDate >= ws) return Season.WINTER;
                if (simulateDate >= fs) return Season.FALL;
                if (simulateDate >= ss) return Season.SUMMER;
                if (simulateDate >= sps) return Season.SPRING;
                return Season.WINTER;
            }

            if (ws.IsBeyondToday) return Season.WINTER;
            if (fs.IsBeyondToday) return Season.FALL;
            if (ss.IsBeyondToday) return Season.SUMMER;
            if (sps.IsBeyondToday) return Season.SPRING;
            return Season.WINTER;
        }
    }

    [CanBeNull]
    public string current_season_jpn
    {
        get
        {
            string season = "夏";
            switch (CURRENT_SEASON)
            {
                case Season.SPRING:
                    season = "春";
                    break;
                case Season.SUMMER:
                    season = "夏";
                    break;
                case Season.FALL:
                    season = "秋";
                    break;
                case Season.WINTER:
                    season = "冬";
                    break;
            }
            return season;
        }
    }
    
    void Reset()
    {
        DateTime now = DateTime.Now;
        Date today = new Date()
        {
            month = now.Month,
            day = now.Day
        };
        simulateDate = today;
        
        springStart = Date.SPRING_START;
        summerStart = Date.SUMMER_START;
        fallStart = Date.FALL_START;
        winterStart = Date.WINTER_START;
    }
    
}
