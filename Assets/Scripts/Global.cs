using UnityEngine;

public static class Global
{
    #region Tags


    #endregion

    #region Axis

    public const string HorizontalLeftStickAxis = "HorizontalLeftStick";
    public const string VerticalLeftStickAxis = "VerticalLeftStick";
    public const string HorizontalRightStickAxis = "HorizontalRightStick";
    public const string VerticalRightStickAxis = "VerticalRightStick";
    public const string JumpAxis = "Jump";
    public const string StartAxis = "Cancel";
    public const string FireAxis = "Fire1";

    #endregion

    #region Scene Names

    public const string MainMenuScene = "Main Menu";
    public const string FirstLevelScene = "Game";

    #endregion

    #region Animations

    #endregion

    #region Constants

    public const double Tolerance = float.Epsilon;

    #endregion

    #region Functions

    public static string ReturnTimeToString(float time)
    {
        var minutes = Mathf.FloorToInt(time / 60f);
        var seconds = Mathf.RoundToInt(time % 60f);

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        if (seconds <= 0)
            seconds = 0;
        if (minutes <= 0)
            minutes = 0;
        
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    #endregion

    #region Enums

    #endregion
}
