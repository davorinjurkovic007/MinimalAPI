namespace DevNot21.Service;

public interface IZipService
{
    IEnumerable<string> ZipResult (List<string> list1, List<string> list2, List<long?> list3);
}
