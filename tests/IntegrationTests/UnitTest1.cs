namespace IntegrationTests;

[Collection("Test collection")]
public class UnitTest1
{
    private readonly SharedTestContext _testContext;

    public UnitTest1(SharedTestContext testContext)
    {
        _testContext = testContext;
    }

    [Fact]
    public void Test1()
    {
    }
}
