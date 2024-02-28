namespace CodeCop010;

public class Example
{
    private readonly BankDetailResponseDto _bankRepo;

    public Example(BankDetailResponseDto bankRepo)
    {
        _bankRepo = bankRepo;
    }

    public async Task<IEnumerable<BankDetailResponseDto>?> GetBankDetails()
    {
        var entities = await _bankRepo.GetAllAsNoTrackingAsync();

        if (!entities.Any)
        {
            return null;
        }

        return Map<IEnumerable<BankDetailResponseDto>>(entities);
    }
}
