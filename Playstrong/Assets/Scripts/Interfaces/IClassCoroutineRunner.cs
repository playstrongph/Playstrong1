using System.Collections;

namespace Interfaces
{
    public interface IClassCoroutineRunner
    {
        IEnumerator Wait(float seconds);
    }
}