namespace CodeCop010;

public class BankDetailResponseDto
{
    public async Task<IEnumerable<BankDetailResponseDto>> GetAllAsNoTrackingAsync()
    {
        await Task.Delay(200);

        return Enumerable.Empty<BankDetailResponseDto>();
    }
}
