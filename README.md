# InputActionEventSystem

![](Images/AddInputEventsGif.gif)

## Description
Input Action Event System is a input system that pairs inputs and events together. this helps with prototyping faster by being able to switch out inputs and events quickly in the inspector.

Following features
- Easy to add and remove Input Action Events in the inspector. 
- Switch out the input types in the inspector. 
- Quick input swapping.
- Multiple events per input.
- BoolData to turn off inputs outside the script.

## Installation
### Third Party Tools

Using Ult Events in the package to expained the Event Sytsem of the tool.

[UltEvent](https://assetstore.unity.com/packages/tools/gui/ultevents-111307#description)

Download the Ult Event tool on the unity assest store.
this tool comes pre installed with this tool.

### Package Manager 

#### Install via git url

Open Window/Package Manager, and add packages from hit URL...

```
https://github.com/MarquisMc/InputActionEventSystem.git
```

## How to use 
### 1. Add InputEvents Component

![](Images/AddInputEventsGif.gif)

### 2. InputEvents Variables

![](Images/InputEventsComponent.PNG)

#### Variables
- Input Name: The name of the input action. EX. Jump
- Current Input Type: The type of input via;
  - MultiTapInput
  - HoldAndPressInput
  - HoldAndWaitInput
- Press Input: The input that has to be pressed for MultiTap. EX. A
- Hold Input: The input that has to held for HoldAndWait and HoldAndPress. EX. D
- Is Listening: A BoolData that has to be dragged in, used to turn on/off Input Events.
- Max Tap Num: Number of taps before the Input Event will be executed for MultiTap. EX. 2
- Tap Duration: Time given to execute the Max Tap Num before resetting back to 0 for MultiTap.
- Hold Time: Time the Hold Input needs to be held down to execute Input Event for HoldAndWait.
- Input Event: Ult Event that will be executed when the input type is executed. 

### 3. Add and Setup Input Types

#### Multi Tap Input
![](Images/MultiTap%20Input%20Type.PNG)

#### Variables for Multi Tap Input
- Press Input
- Is Listening Bool Data
- Max Tap Num
- Tap Duration
- Input Event

#### Hold And Press Input
![](Images/HoldandPress%20Input%20Type.PNG)

#### Variables for Hold And Press Input
- Press Input
- Hold Input
- Is Listening Bool Data
- Input Event

#### Hold And Wait Input
![](Images/HoldandWait%20Input%20Type.PNG)

#### Variables for Hold And Wait Input
- Hold Input 
- Hold Time
- Input Event

### 4. Using BoolData

![](Images/BoolDataToListeningGif.gif)

#### Code Example on how to use A BoolData
``` C#
public bool UsingBoolData(TextMeshProUGUI text, BoolData boolData)
{
    if (text.text != "Counter: 100") 
    {
        boolData.SetData(false);
        return false;
    }

    return boolData.GetData();
}
```
### Live Examples

#### MultiTap Live

![](Images/MultiTapLiveGif.gif)

#### HoldAndPress Live

![](Images/HoldAndPressLiveGif.gif)

#### HoldAndWait Live 

![](Images/HoldInputLiveGif.gif)

## Support 

Need support or have ideas for new features for this tool 
Contact me at reachmarquismccann@gmail.com

## License 
[MIT](https://choosealicense.com/licenses/mit/)
