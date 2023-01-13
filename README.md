Prerequisites:
              1) Visual Studio 2022 Community Edition.<br/>
              2) Sql Server Management Studio 2019.<br/>
              3) .Net Framework 4.5.1<br/>
             
How To Run The Project:
                       Step 1: Download Repo..
                      <img width="960" alt="1" src="https://user-images.githubusercontent.com/73866050/212383565-0af813a2-5954-475c-a73c-7855486f0281.png">

                       step 2: Create Database With Use Of ExpanceDb.sql file
                       
                       step 3: Go to visual studio and choose open project solution option
                       <img width="960" alt="2" src="https://user-images.githubusercontent.com/73866050/212386854-0ab57a63-0bfb-44fa-a905-74a003e8b940.png">


                       step 4: select the ExpanceMvc.sln file from ExpanceMvc/ExpanceMvc.sln then hit open 
                      <img width="948" alt="3" src="https://user-images.githubusercontent.com/73866050/212386953-ccaf85b9-021f-4cee-8fd1-0dc2fbd33146.png">


                       step 5: change the path of local server in GlobalVariables.cs file from ExpanceMvc/GlobalVariables.cs in file there is path given of local host
                       
                       https://localhost:44303/api/ change the port number for finding port number click ExpanceApi folder in solution expolore and then right click,
                       then choose properties, then go tu the web there will be meniond path of local host copy it and pase the your path, leave /api/ as it is then save the file.
                     <img width="704" alt="4" src="https://user-images.githubusercontent.com/73866050/212387007-66492c88-9912-445f-ac38-522c24f23a51.png">


                       step 6: right click on solution in solution explorer and go to the properties select common properties select multiple startup project and select start option for both files ExpanceApi And ExpanceMvc then hit ok. 
                      <img width="957" alt="5" src="https://user-images.githubusercontent.com/73866050/212387058-e30780ca-5b44-4801-a838-af7d5022f8e0.png">


                       step 7: press ctrl+f5 for run project.
                       
Note : if i was putting all the files in same folder then it is giving errors thats why i have created 2 differrent folder but solution file is only one which is in ExpanceMvc folder

- internet connection is required for load bootstrap.


Screen shots:

1 Dashboard:
<img width="929" alt="1dash " src="https://user-images.githubusercontent.com/73866050/212385953-f8b3f3a9-bc5f-457d-8f01-e50cadd1ad1d.png">

2 Add category
<img width="929" alt="2addcat" src="https://user-images.githubusercontent.com/73866050/212386023-48e194cc-ce43-4c39-bed4-86086ff67349.png">

3 view category
<img width="941" alt="3viewcat" src="https://user-images.githubusercontent.com/73866050/212386146-70f9a24b-17c3-42fb-a8d2-05d6e6d6d0c9.png">

4 add expance
<img width="938" alt="4addexp" src="https://user-images.githubusercontent.com/73866050/212386203-c92a3ca5-7b96-42ac-916f-6407ccc92a53.png">

5 view expance
<img width="946" alt="5viewexp" src="https://user-images.githubusercontent.com/73866050/212386252-0e5720c3-0953-45e4-b4c3-7525cac2f184.png">

6 view total expance
<img width="942" alt="6viewtotexp" src="https://user-images.githubusercontent.com/73866050/212386306-ee76c1a4-867a-499f-b192-6dac43217d99.png">

