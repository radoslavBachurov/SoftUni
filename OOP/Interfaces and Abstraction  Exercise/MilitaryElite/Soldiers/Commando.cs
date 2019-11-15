using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Soldiers
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        List<Mission> missions;
        public Commando(string id, string firstName, string lastName, string corps, decimal salary)
            : base(id, firstName, lastName, corps, salary)
        {
            missions = new List<Mission>();
        }

        public IReadOnlyCollection<Mission> Missions => this.missions;

        public void AddMissions(string name, string state)
        {
            if (state == "Finished" || state == "inProgress")
            {
                this.missions.Add(new Mission(name, state));
            }
        }

        public void CompleteMission(string name)
        {
            Mission toChange = missions.Find(x => x.CodeName == name);
            toChange.CompleteMission();
        }

        public override string ToString()
        {
            var newSb = new StringBuilder();
            newSb.AppendLine($"{base.ToString()}");
            newSb.AppendLine("Missions:");
            foreach (var mission in this.missions)
            {
                newSb.AppendLine($"  {mission.ToString()}");
            }
            return newSb.ToString().Trim();
        }
    }
}
