# UnityScreenShot
A little tool to automate making screenshots for your Unity projects 
Takes screenshots at three moments: 
- when the Unity project is loaded
- when you enter Play mode
- whenever you press the Space key in play mode

## Usage:
### Set path for screenshots
Open ScreenShot.cs and set the customFilePath string to the path where you want to save your screenshots

![Alt text](media/customfilepath.png) 

---

### Export script as UnityPackage
Drop ScreenShot.cs in any open Unity project, right click the file and export it as a package file. 
Save the path to your newly exported .unitypackage file.

![Alt text](media/exportpackage.png)

---

### Unity Hub  Command Line Arguments 
In Unity Hub, select options for each of your projects and select "Add command line arguments"

![Alt text](media/cli.png) 

---

### Enter Command Line Arguments 
In the input box, enter:

```-importpackage "path/to/screenshotpackage.unitypackage"```

![Alt text](media/cli-edit.png) 

---

### Open the project 
When you open the project, the ScreenShot.cs file is imported into your project, and takes a screenshot when the project is finished loading.
Enter Playmode, and press Spacebar to make additional screenshots while the project is running.

![Alt text](media/playmode.png) 
