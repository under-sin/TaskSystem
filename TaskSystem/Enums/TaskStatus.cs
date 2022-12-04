using System.ComponentModel;

namespace TaskSystem.Enums;

public enum StatusTask
{
    [Description("To do")]
    Todo = 1,
    [Description("In progress")]
    InProgress = 2,
    [Description("Concluded")]
    Concluded = 3,
}
