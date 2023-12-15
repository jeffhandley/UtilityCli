using static UtilityCli.CliArgs;
namespace UtilityCli.Test;

public class RequiredValues
{
    [Fact]
    public void MissingArgument_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredBoolean());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredByte());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredInt16());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredInt32());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredInt64());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredSingle());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredDouble());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredDecimal());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredString());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredChar());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredDateTime());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredDateTimeOffset());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredGuid());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredSByte());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredUInt16());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredUInt32());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredUInt64());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredBooleans());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredBytes());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredInt16s());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredInt32s());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredInt64s());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredSingles());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredDoubles());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredDecimals());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredStrings());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredChars());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredDateTimes());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredDateTimeOffsets());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredGuids());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredSBytes());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredUInt16s());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredUInt32s());
        Assert.Throws<ArgumentNullException>(() => Parse([]).GetRequiredUInt64s());

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

        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredBoolean(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredBoolean(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredBoolean(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredByte(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredByte(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredByte(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt16(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt16(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt16(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt32(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt32(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt32(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt64(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt64(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt64(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredSingle(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredSingle(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredSingle(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDouble(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDouble(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDouble(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDecimal(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDecimal(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDecimal(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredString(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredString(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredString(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredChar(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredChar(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredChar(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDateTime(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDateTime(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDateTime(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDateTimeOffset(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDateTimeOffset(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDateTimeOffset(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredGuid(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredGuid(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredGuid(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredSByte(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredSByte(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredSByte(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt16(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt16(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt16(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt32(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt32(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt32(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt64(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt64(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt64(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredBooleans(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredBooleans(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredBooleans(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredBytes(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredBytes(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredBytes(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt16s(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt16s(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt16s(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt32s(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt32s(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt32s(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt64s(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt64s(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredInt64s(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredSingles(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredSingles(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredSingles(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDoubles(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDoubles(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDoubles(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDecimals(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDecimals(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDecimals(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredStrings(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredStrings(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredStrings(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredChars(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredChars(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredChars(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDateTimes(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDateTimes(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDateTimes(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDateTimeOffsets(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDateTimeOffsets(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredDateTimeOffsets(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredGuids(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredGuids(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredGuids(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredSBytes(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredSBytes(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredSBytes(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt16s(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt16s(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt16s(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt32s(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt32s(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt32s(name, aliases, shortNames));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt64s(name));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt64s(name, shortName));
        Assert.Throws<ArgumentNullException>(() => Parse(args).GetRequiredUInt64s(name, aliases, shortNames));
    }
}
