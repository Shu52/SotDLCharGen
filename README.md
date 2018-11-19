# SotDLCharGen
Back end capstone.
Character Generator for RPG Shadow of the Demon Lord

## Live Demo
https://sotdlchargen20181108085431.azurewebsites.net/

##### Tools Used
- Visual Studio 2017
- Microsoft SQL server Managment Studio

### Installation

Create a directory and `git clone` the repository

Open `SotDLChargen.sln` with Visual Studio 2017

Create an `appsetting.json` file similar to this
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server = [YOUR DESKTOP\\SqlExpress];Database=CharGen;Trusted_Connection=True;"
  }
}
```
In Visual Studio 2017 got to `Tools => Nuget Package Manager => Package Manager Console`

In the Package Manager Console type `Update -Database` and enter. This will build the database.

### Useage

Create an Acoountwith a Username, Email, and Password

The page will show a list of the user's created characters. The list will be empty is the user does not have a character.

##### Create

Click on the "Create New" Link to bring up the form to create a new character

Provide input for Character Name and Gender.

Select 0 for Level and "Human" for Ancestries

Click "Create"

The user will be provided with a form that allow a Character with the Ancestry of "Human" to increase two out of the four abilities by one

Increase Two of the Four Abilities by One and click Create

User will be returned to their user index page with a list of their characters.

##### Edit

On the user index page, the user clicks the "Edit" link.

The user will be presented with a Form giving the user the affordance to edit the Character's name and gender.

Click the "save button" and the fields will be updated.

##### Details

On the user index page, the user clicks the "Details" link.

The user can view the character's Character Name, Gender, Level, Ancestry, Strength, Agility, Intelect, Will, Hit points, and Healing rate.

##### Delete
On the user Index page, the user clicks "Delete".

The user will be presented with confrimation of delete view

User clicks on "Delete"

The character is deleted and the user is returned to the user's Index view



