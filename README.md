<a name="readme-top"></a>

<br />
<div align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src="https://pbs.twimg.com/profile_images/1602061356315860992/wP4rpPJQ_400x400.jpg" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Tournament Tracker Application</h3>
</div>

![image](https://github.com/DavidV1600/TournamentTracker/assets/115104357/917b0013-bd40-4cc2-949d-e242e3309c46)

## About The Project
Why am I building this?
* Because I want to make an app that also has a decent looking UI, and also because I want to make use of the Databases knowledge I gained recently

### Built With

* Net.Core v7.0
* Dapper
* MySqlConnector

### Installation

   Clone the repo
   ```sh
   git clone https://github.com/DavidV1600/TournamentTracker.git
   ```

   
<!-- USAGE EXAMPLES -->
## Usage
The Project can save data in both Sql and Txt format, but because my Database is local you cannot save to it so, instead go to Program.cs and set the connection only for Txt or only copy the line below and change it with the one in the code.
   ```sh
               TrackerLibrary.GlobalConfig.InitializeConnections(false,true);//1-Sql, 2-Txt
   ```
After that you have to go in TextConnectorProccesor and change the FullFilePath() function, and instead of the return line there put the location where you want your data to be saved
   ```sh
                           return $"YourSavingLocation//{FileName}";
   ```
To Run the Project simply select TrackerUI as the StartUp Project if it isn't already and click Run. 


### References
Tim Corey Tutorial - https://www.youtube.com/watch?v=HalXZUHfKLA&list=PLLWMQd6PeGY3t63w-8MMIjIyYS7MsFcCi

Dapper Official Site - https://dappertutorial.net/

Microsoft Page for using SSMS - https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
