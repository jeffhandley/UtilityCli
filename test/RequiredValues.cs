using static UtilityCli.CliArgs;
namespace UtilityCli.Test;

public class RequiredValues
{
    [Fact]
    public void MissingArgument_Throws()
    {
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredBoolean());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredByte());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredInt16());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredInt32());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredInt64());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredSingle());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredDouble());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredDecimal());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredString());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredChar());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredDateTime());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredDateTimeOffset());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredGuid());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredSByte());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredUInt16());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredUInt32());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredUInt64());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredBooleans());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredBytes());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredInt16s());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredInt32s());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredInt64s());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredSingles());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredDoubles());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredDecimals());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredStrings());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredChars());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredDateTimes());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredDateTimeOffsets());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredGuids());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredSBytes());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredUInt16s());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredUInt32s());
        Assert.Throws<ArgumentException>(() => Parse([]).GetRequiredUInt64s());

    }

    [Theory]
    [InlineData(new string[0], true)]
    [InlineData(new string[] { "argument_value" }, true)]
    [InlineData(new string[] { "argument_value", "--other-flag" }, true)]
    [InlineData(new string[] { "--other-flag" }, true)]
    [InlineData(new string[] { "--other-option", "option_value" }, true)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "<Pending>")]
    public void MissingOption_Throws(string[] args, bool workAroundAttributeIssue)
    {
        string name = "option-name";
        char shortName = 'o';
        string[] aliases = ["option"];
        char[] shortNames = ['o', 'n'];

        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredBoolean(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredBoolean(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredBoolean(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredByte(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredByte(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredByte(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt16(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt16(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt16(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt32(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt32(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt32(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt64(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt64(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt64(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredSingle(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredSingle(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredSingle(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDouble(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDouble(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDouble(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDecimal(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDecimal(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDecimal(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredString(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredString(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredString(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredChar(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredChar(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredChar(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDateTime(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDateTime(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDateTime(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDateTimeOffset(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDateTimeOffset(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDateTimeOffset(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredGuid(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredGuid(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredGuid(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredSByte(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredSByte(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredSByte(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt16(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt16(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt16(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt32(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt32(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt32(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt64(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt64(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt64(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredBooleans(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredBooleans(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredBooleans(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredBytes(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredBytes(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredBytes(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt16s(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt16s(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt16s(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt32s(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt32s(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt32s(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt64s(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt64s(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredInt64s(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredSingles(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredSingles(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredSingles(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDoubles(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDoubles(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDoubles(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDecimals(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDecimals(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDecimals(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredStrings(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredStrings(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredStrings(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredChars(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredChars(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredChars(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDateTimes(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDateTimes(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDateTimes(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDateTimeOffsets(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDateTimeOffsets(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredDateTimeOffsets(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredGuids(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredGuids(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredGuids(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredSBytes(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredSBytes(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredSBytes(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt16s(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt16s(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt16s(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt32s(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt32s(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt32s(name, aliases, shortNames));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt64s(name));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt64s(name, shortName));
        Assert.Throws<ArgumentException>(() => Parse(args).GetRequiredUInt64s(name, aliases, shortNames));
    }
}
