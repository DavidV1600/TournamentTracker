﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAcces
{
    public interface IDataConnection
    {
        Prize CreatePrize(Prize model);

        Person CreatePerson(Person model);

        Team CreateTeam(Team model);

        List<Person> GetPerson_All();

        List<Team> GetTeam_All();
    }
}
