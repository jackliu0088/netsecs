using Secs4Net;
using Secs4Net.Json;
using System.Collections.ObjectModel;

namespace TextServer
{
    public sealed class SecsMessageList : ObservableCollection<SecsMessage> {
        public SecsMessageList(string jsonFile) : base(File.OpenRead(jsonFile).ToSecsMessages()) { }

        public SecsMessage? this[byte s, byte f, string name] => this[s, f].FirstOrDefault(m => m.Name == name);

        public IEnumerable<SecsMessage> this[byte s, byte f] => this.Where(m => m.S == s && m.F == f);

        public SecsMessage? this[string name] => this.FirstOrDefault(m => m.Name == name);
    }
}
