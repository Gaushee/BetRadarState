﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIC.Sport.Stats.Collector.Cache.CacheData
{
    /// <summary>
    /// 队伍在不同赛季下的队员信息
    /// </summary>
    public class TeamPlayers : BaseCacheEntity
    {
        public string SeasonId;
        public string TeamId;
        public Dictionary<string, string> BestPlayerDic = new Dictionary<string, string>();    //  kv = 名次--PlayerId
        public Dictionary<string, string> CardPlayerDic = new Dictionary<string, string>();    //  kv = 名次--PlayerId
        public Dictionary<string, string> AssistsPlayerDic = new Dictionary<string, string>();    //  kv = 名次--PlayerId
        public Dictionary<string, InjurePlayer> InjurePlayerDic = new Dictionary<string, InjurePlayer>();    //  kv = PlayerId--伤停状态描述
        public List<string> AllPlayerIdList = new List<string>();   //  球队名单
        public Dictionary<string, List<string>> ComparePlayerIdList(List<string> list)
        {
            var adds = list.Except(AllPlayerIdList).ToList();
            var dels = AllPlayerIdList.Except(list).ToList();

            AllPlayerIdList = list;
            return new Dictionary<string, List<string>> { { "add", adds }, { "del", dels } };
        }

        public override string GetKey()
        {
            return TeamId + "_" + SeasonId;
        }
    }

    public class InjurePlayer
    {
        public int PlayerId;
        public bool IsMissing;
        public string Status;

    }
}
