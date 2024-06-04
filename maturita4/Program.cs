using System.Reflection.Metadata;

string t = "{START:outer}\r\n\ttext\r\n   {STAR:inner} {START:inner}text{END:inner}\r\n{END:outer}";
string jednodusi = "";
bool b = false;
bool validation = true;
Stack<string> stack = new Stack<string>();
Stack<string> stackEND = new Stack<string>();

for (int i = 0; i < t.Length; i++)
{
    if (t[i] == '{')
    {
        b = true;
    }
    else if (t[i] == '}')
    {
        jednodusi = jednodusi + t[i];
        b = false;
    }
    if (b)
    {
        jednodusi += t[i];
    }
    
}

string[]bloky = jednodusi.Split('}');
foreach (var blok in bloky)
{
    Console.WriteLine(blok);
}
for (int i = 0;i < bloky.Length; i++)
{
    if (bloky[i].Contains("START") || bloky[i].Contains("END"))
    {
        stack.Push(bloky[i]);
    }
    else
    {
        bloky[i] = null;
    }
}

while (true)
{
    if (stackEND.Count==0 && stack.Count == 0)
    {
        break;
    }
    else if (stack.Count == 0 && stack.Count != 0)
    {
        validation = false;
        break;
    }
    string s =stack.Pop();
    if (s.Contains("END"))
    {
        stackEND.Push(s);
    }
    else
    {
        string end = stackEND.Pop();
        string[] key = s.Split(":");
        if (!end.Contains(key[1]))
        {
            validation=false;
            break;
        }
    }
}
if (validation)
{
    Console.WriteLine("validni");
}
else
    Console.WriteLine("nevalidni");


