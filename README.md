# ![](https://user-images.githubusercontent.com/53557479/150516207-a34fb46a-f2c4-403d-ab92-ba56634d2271.png) MoonMissing [In Development] [![](https://img.shields.io/github/license/tomshiii/MoonMissing?color=orange)](https://github.com/tomshiii/MoonMissing/blob/main/LICENSE)

This program serves the Super Mario Odyssey speedrunning community for runs including All Moons & 100%.

When performing a speedrun, If you notice that you're missing a moon towards the end of the run, this application allows fast lookup of moon information! Within the program, you can select the desired kingdom and the corresponding moon number and quickly know which moon you need to go back and collect!

Before this tool, finding which moon is missing was a manual process involving the runner using a search engine and reading through an online guide, such as one by IGN. MoonMissing is a project that aims to mitigate the cumbersome navigability of websites that distract the viewer with irrelevant ads and materials, to return the player to the speedrun as fast as possible.

## How does this application work?

This application comes with a pre-prepared database file (*.db) and uses SQLite internally to query data. As you navigate the application, the database is queried asynchronously to get the relevant information for each moon, including name, kingdom, location, and images of the moon.

## How can you help?

If you are interested in helping with the project, please make a fork of the project and make your changes within the Main branch before submitting a pull request.

Any images must be 1080p+ screenshots direct from the Nintendo Switch or via OBS' built-in screenshot function.

## Project Layout

- MoonMissing: The project developing the WPF application.
- MoonMissing.Data: The data layer used by different projects within the solution. Holds models and entities for the database.
- MoonMissing.Data.Assistant: Helper project for mutating various aspects of the input data. For example: modifying and extending the original json file containing moon data.
- MoonMissing.Data.Deploy: The deployment project tasked with building database migrations and population.
- MoonMissing.WPF.Shared: Shared assets between projects.

## Requirements

- .NET 6 Runtime
