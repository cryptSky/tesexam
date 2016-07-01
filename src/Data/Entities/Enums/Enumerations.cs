using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Enums
{
    public enum QustionType
    {
        SingleChoice,
        MultipleChoice,
        Response
    }

    public enum AnswerType
    {
        Id,
        ListIds,
        TextData,
        LatexData,
        SourceCode,
        GeoSpartialData,
        SoundData,
        ImageData
    }

    public enum ControlType
    {
        TextBox,
        Image,
        List
    }
}
