﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QIC.Sport.Stats.Collector.Cache.CombinedData;

namespace QIC.Sport.Stats.Collector.Cache.CacheData
{
    public class SeasonEntity : BaseCacheEntity
    {
        public string SeasonId;
        public string SportId;
        public string SeasonName;
        public string TotalRound;
        public string CurrentRound;
        public int Status;
        public List<int> SeasonTypeList = new List<int>();
        public List<string> TeamIdList = new List<string>();

        public Dictionary<string, List<string>> CompareTeamIdList(List<string> list)
        {
            var adds = list.Except(TeamIdList).ToList();
            var dels = TeamIdList.Except(list).ToList();

            TeamIdList = list;
            return new Dictionary<string, List<string>> { { "add", adds }, { "del", dels } };
        }
    }
}
