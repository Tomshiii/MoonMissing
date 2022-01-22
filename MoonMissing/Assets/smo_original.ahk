#SingleInstance Force
SetWorkingDir(A_ScriptDir)
TraySetIcon("C:\Program Files\ahk\MoonMissing\Images\icon.ico")

/*
 * 
 This AHK script is the original basis for this whole project - this script is barely functional or feature rich but was what started conversations
 */

MainGui := Gui("AlwaysOnTop", "Which kingdom are you missing a moon in?")
MainGui.Opt("+Resize +MinSize420x200") ;Sets a minimum size for the window

CapGui := MainGui.Add("Picture", "w200 h-1", A_WorkingDir "\Images\1. cap.png")
CapGui.OnEvent("Click", Cap)

CascadeGui := MainGui.Add("Picture", "w200 h-1 X215 Y6", A_WorkingDir "\Images\2. cascade.png")
CascadeGui.OnEvent("Click", Cascade)

MainGui.Show()
Cap(*) {
    MainGui.Destroy()
    CapKingdom := Gui("AlwaysOnTop", "Cap Kingdom")
    CapKingdom.Opt("+Resize +MinSize300x200") ;Sets a minimum size for the window

    MoonIcon := CapKingdom.Add("Picture", "w50 h-1", A_WorkingDir "\Images\moon1.png")

    Goback := CapKingdom.Add("Button", "w40 X15 Y72", "Go Back")
    Goback.OnEvent("Click", GoMain)

    Moon1 := CapKingdom.Add("Button", "w60 Y8", "1")
    Moon1.OnEvent("Click", MoonOne)

    Moon2 := CapKingdom.Add("Button", "w60 Y8", "2")
    Moon2.OnEvent("Click", MoonTwo)

    Moon3 := CapKingdom.Add("Button", "w60 Y8", "3")
    Moon3.OnEvent("Click", MoonThree)

    Moon4 := CapKingdom.Add("Button", "w60 Y8", "4")
    Moon4.OnEvent("Click", MoonFour)

    Moon5 := CapKingdom.Add("Button", "w60 X70 Y40", "5")
    Moon5.OnEvent("Click", MoonFive)

    Moon6 := CapKingdom.Add("Button", "w60 X140 Y40", "6")
    Moon6.OnEvent("Click", MoonSix)

    Moon7 := CapKingdom.Add("Button", "w60 X210 Y40", "7")
    Moon7.OnEvent("Click", MoonSeven)
    
    Moon8 := CapKingdom.Add("Button", "w60 X280 Y40", "8")
    Moon8.OnEvent("Click", MoonEight)
    
    Moon9 := CapKingdom.Add("Button", "w60 X70 Y72", "9")
    Moon9.OnEvent("Click", MoonNine)

    Moon10 := CapKingdom.Add("Button", "w60 X140 Y72", "10")
    Moon10.OnEvent("Click", MoonTen)

    Moon11 := CapKingdom.Add("Button", "w60 X210 Y72", "11")
    Moon11.OnEvent("Click", MoonEleven)

    Moon12 := CapKingdom.Add("Button", "w60 X280 Y72", "12")
    Moon12.OnEvent("Click", MoonTwelve)

    Moon13 := CapKingdom.Add("Button", "w60 X70 Y104", "13")
    Moon13.OnEvent("Click", MoonThirteen)

    Moon14 := CapKingdom.Add("Button", "w60 X140 Y104", "14")
    Moon14.OnEvent("Click", MoonFourteen)

    Moon15 := CapKingdom.Add("Button", "w60 X210 Y104", "15")
    Moon15.OnEvent("Click", MoonFifteen)

    Moon16 := CapKingdom.Add("Button", "w60 X280 Y104", "16")
    Moon16.OnEvent("Click", MoonSixteen)

    Moon17 := CapKingdom.Add("Button", "w60 X70 Y136", "17")
    Moon17.OnEvent("Click", MoonSeventeen)

    Moon18 := CapKingdom.Add("Button", "w60 X140 Y136", "18")
    Moon18.OnEvent("Click", MoonEighteen)

    Moon19 := CapKingdom.Add("Button", "w60 X210 Y136", "19")
    Moon19.OnEvent("Click", MoonNineteen)

    Moon20 := CapKingdom.Add("Button", "w60 X280 Y136", "20")
    Moon20.OnEvent("Click", MoonTwenty)

    Moon21 := CapKingdom.Add("Button", "w60 X70 Y168", "21")
    Moon21.OnEvent("Click", MoonTwentyOne)

    Moon22 := CapKingdom.Add("Button", "w60 X140 Y168", "22")
    Moon22.OnEvent("Click", MoonTwentyTwo)

    Moon23 := CapKingdom.Add("Button", "w60 X210 Y168", "23")
    Moon23.OnEvent("Click", MoonTwentyThree)

    Moon24 := CapKingdom.Add("Button", "w60 X280 Y168", "24")
    Moon24.OnEvent("Click", MoonTwentyFour)

    Moon25 := CapKingdom.Add("Button", "w60 X70 Y200", "25")
    Moon25.OnEvent("Click", MoonTwentyFive)
    
    Moon26 := CapKingdom.Add("Button", "w60 X140 Y200", "26")
    Moon26.OnEvent("Click", MoonTwentySix)

    Moon27 := CapKingdom.Add("Button", "w60 X210 Y200", "27")
    Moon27.OnEvent("Click", MoonTwentySeven)
    
    Moon27 := CapKingdom.Add("Button", "w60 X280 Y200", "28")
    Moon27.OnEvent("Click", MoonTwentyEight)

    Moon27 := CapKingdom.Add("Button", "w60 X70 Y232", "29")
    Moon27.OnEvent("Click", MoonTwentyNine)

    Moon27 := CapKingdom.Add("Button", "w60 X140 Y232", "30")
    Moon27.OnEvent("Click", MoonThirty)

    Moon27 := CapKingdom.Add("Button", "w60 X210 Y232", "31")
    Moon27.OnEvent("Click", MoonThirtyOne)

    CapKingdom.Show()

    ResultGUI(number, rockyorn, title, quadrant, body, moon)
    {
        CapKingdom.Destroy()
        Result := Gui("AlwaysOnTop", "Cap Kingdom")
        Result.Opt("+Resize +MinSize400x300") ;Sets a minimum size for the window
        MoonIcon2 := Result.Add("Picture", "w50 h-1", A_WorkingDir "\Images\moon1.png")
        Goback2 := Result.Add("Button", "w40 X8 Y72", "Go to Kingdoms")
        Goback2.OnEvent("Click", reload2)

        if %&rockyorn% = "y"
            rock := " || Moon Rock Required"
        else
            rock := ""

        ;TITLE
        Number := Result.Add("Text", "X80 Y8 H60 W380 -Wrap", "Moon " %&number% rock)
        Number.SetFont("S12 W600")

        ;TITLE
        Title := Result.Add("Text", "X80 Y40 H60 W380 -Wrap", %&title%)
        Title.SetFont("S12 W600")

        ;QUADRANT
        Quad := Result.Add("Text", "X80 Y70 W350", "Quadrant " %&quadrant%)
        Quad.SetFont("S10 W600")

        ;BODY TEXT
        Body := Result.Add("Text", "X80 Y100 W350 h180 +Wrap", %&body%)
        Body.SetFont("S11 W400")

        ;MOON IMAGE
        moon1 := Result.Add("Picture", "w450 h-1 ym+5", A_WorkingDir "\Images\cap\" %&moon% ".png")

        Result.Show()

        reload2(*) {
            Result.Destroy()
            Reload()
        }
    }

    GoMain(*) {
        CapKingdom.Destroy()
        Reload()
    }
    
    MoonOne(*) {
        ResultGUI("1 -", "", "Frog-Jumping Above the Fog", "D2", "This Moon is towards the bottom of cap kingdom and is acquired by capturing a frog and knocking open an invisible block", "cap1")
    }
    MoonTwo(*) {
        ResultGUI("2 -", "", "Frog-Jumping the Top Deck", "C2", "This Moon is towards the bottom the central plaza part of the kingdom and is acquired by capturing a frog and jumping on top of one of the little hat houses", "default")
    }
    MoonThree(*) {
        ResultGUI("3 -", "", "Cap Kingdom Timer Challenge 1", "B4", "This Moon is started by activating the scarecrow towards the right side of the horizontal bridge towards the top of the kingdom", "default")
    }
    MoonFour(*) {
        ResultGUI("4 -", "", "Good Evening, Captain Toad!", "B4", "This Moon is can be found atop the Top Hat Tower", "default")
    }
    MoonFive(*) {
        ResultGUI("5 -", "", "Shopping in Bonneton", "C2 && C3", "This Moon is located in the middle of the central plaza at the shop", "default")
    }
    MoonSix(*) {
        ResultGUI("6 -", "", "Skimming the Poison Tide", "B4", "This Moon is located in the top hat door behind and below Top Hat Tower.`nThis moon is the shards moon, NOT the secret moon", "default")
    }
    MoonSeven(*) {
        ResultGUI("7 -", "", "Slipping Through the Poison Tide", "B4", "This Moon is located in the top hat door behind and below Top Hat Tower.`nThis moon is the secret moon, NOT the shards moon", "default")
    }
    MoonEight(*) {
        ResultGUI("8 -", "", "Push-Block Peril", "B4", "This Moon is located in the top hat door on the north side of Top Hat Tower.`nThis moon is the main moon, NOT the secret moon", "default")
    }
    MoonNine(*) {
        ResultGUI("9 -", "", "Hidden Among the Push-Blocks", "B4", "This Moon is located in the top hat door on the north side of Top Hat Tower.`nThis moon is the secret moon hidden in one of the moving blocks, NOT the main moon", "default")
    }
    MoonTen(*) {
        ResultGUI("10 -", "", "Searching the Frog Pond", "B2", "This Moon is located in the top hat door on the north side of the central plaza.`nThis moon is the main moon, NOT the secret moon", "default")
    }
    MoonEleven(*) {
        ResultGUI("11 -", "", " Secrets of the Frog Pond", "B2", "This Moon is located in the top hat door on the north side of the central plaza.`nThis moon is the main shards moon, NOT the secret moon", "default")
    }
    MoonTwelve(*) {
        ResultGUI("12 -", "", "The Forgotten Treasure", "B2", "This Moon is located in the top hat door on the north side of the central plaza.`nThis moon is the secret moon at the top of the room, NOT the main moon", "default")
    }
    MoonThirteen(*) {
        ResultGUI("13 -", "", "Taxi Flying Through Bonneton", "B2", "This Moon is activated by capturing the binoculars on the north side of central plaza and looking at the taxi flying in the sky", "default")
    }
    MoonFourteen(*) {
        ResultGUI("14 -", "", "Bonneter Blockade", "C3", "This Moon is towards the bottom right side of the central plaza and is acquired by capturing a paragoomba and scaring away the bonneter blocking the moon", "default")
    }
    MoonFifteen(*) {
        ResultGUI("15 -", "", "Cap Kingdom Regular Cup", "B4", "This is the first koopa freerunning moon", "default")
    }
    MoonSixteen(*) {
        ResultGUI("16 -", "", "Peach in the Cap Kingdom", "B3", "This moon can be found on the north size of the central plaza and can be acquired by talking to peach", "default")
    }
    MoonSeventeen(*) {
        ResultGUI("17 -", "", "Found with Cap Kingdom Art", "--", "This moon can be found in Moon Kingdom by viewing the hint art on the side of the steps heading towards the north bridge. This moon is then acquired by groundpounding next to the collection of NPC's in post game Moon kingdom that are staring at earth", "default")
    }
    MoonEighteen(*) {
        ResultGUI("18", "y", "Next to Glasses Bridge", "C2", "This moon can be found next to the bridge in the middle of the kingdom. Jump off the west side of the bridge and you should see it on top of a top hat building", "default")
    }
    MoonNineteen(*) {
        ResultGUI("19", "y", "Danger Sign", "D1", "This moon can be found far on the west side of the kingdom and can be acquired by capturing a paragoomba and flying out to the danger sign", "default")
    }
    MoonTwenty(*) {
        ResultGUI("20", "y", "Under the Big One's Brim", "B4", "This moon can be found under the brim of the Top Hat Tower and can be aquired by heading up to the top via warp or through the room then looking over the edge slight to the North West", "default")
    }
    MoonTwentyOne(*) {
        ResultGUI("21", "y", "Fly to the Edge of the Fog", "B5", "This moon can be found all the way out at the far north east part of the kingdom and can be acquired by jumping off Top Hat Tower or capturing a paragoomba and flying over", "default")
    }
    MoonTwentyTwo(*) {
        ResultGUI("22", "y", "Spin the Hat, Get a Prize", "C3", "This moon can be activated on the bottom side of the central plaza by throwing cappy at the glowing Top Hat on the top of the arch", "default")
    }
    MoonTwentyThree(*) {
        ResultGUI("23", "y", "Hidden in a Sunken Hat", "C3", "This moon can be activated out the south east side of the central plaza capturing a paragoomba and flying out to the Top Hat building with a glowing top piece, then throwing and holding cappy ontop of it", "default")
    }
    MoonTwentyFour(*) {
        ResultGUI("24", "y", "Fog-Shrouded Platform", "B2 && B3", "This moon can be found over the edge of the north side of the central plaza. Groundpound the glowing spot of the platform to activate the moon", "default")
    }
    MoonTwentyFive(*) {
        ResultGUI("25", "y", "Bird Traveling in the Fog", "--", "This moon can be found all over the kingdom as the bird is on a cycle and will fly around the kingdom. This moon can be acquired by capturing a paragoomba and catching it", "default")
    }
    MoonTwentySix(*) {
        ResultGUI("26", "y", "Caught Hopping Near the Ship", "D2", "This moon can be found on the hill north of the odyssey. Capture the bunny to get the moon", "default")
    }
    MoonTwentySeven(*) {
        ResultGUI("27", "y", "Taking Notes: In the Fog", "D1", "This moon can be found on the west side of the kingdom and can be acquired by capturing a paragoomba and flying out to the building with the music night, then flying along and collecting all the music notes", "default")
    }
    MoonTwentyEight(*) {
        ResultGUI("28", "y", "Cap Kingdom Timer Challenge 2", "C3", "This moon can be activated by throwing cappy on the scarecrow on the south east side of the central plaza, then grabbing the key to unlock the moon", "default")
    }
    MoonTwentyNine(*) {
        ResultGUI("29", "y", "Cap Kingdom Master Cup", "D4", "This is the second koopa freerunning moon", "default")
    }
    MoonThirty(*) {
        ResultGUI("30", "y", "Roll On and On", "C2", "This is the moon at the end of the moon pipe moon found in the north west side of the central plaza, this is NOT the 'secret' moon", "default")
    }
    MoonThirtyOne(*) {
        ResultGUI("31", "y", "Precision Rolling", "C2", "This is the moon found along the side path of the moon pipe moon found in the north west side of the central plaza, this is the 'secret' moon", "default")
    }
}

Cascade(*) {
    MainGui.Destroy()
    CascadeKingdom := Gui("AlwaysOnTop", "Cascade Kingdom")
    CascadeKingdom.Opt("+Resize +MinSize300x200") ;Sets a minimum size for the window

    MoonIcon := CascadeKingdom.Add("Picture", "w50 h-1", A_WorkingDir "\Images\moon1.png")

    Goback := CascadeKingdom.Add("Button", "w40 X15 Y72", "Go Back")
    Goback.OnEvent("Click", GoMain)

    CascadeKingdom.Show()

    GoMain(*) {
        CascadeKingdom.Destroy()
        Reload()
    }
}