using System;

public class Decode
{
    int i=0;
    string code;
    string st = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    class Memory
    {
        public string[] s = new string[100];
        public int[] i = new int[100];
        public bool[] b = new bool[100];
    }
    Memory M;
	public Decode(string inputcode)
	{
        code = inputcode;
        M = new Memory();
        instruct();
        
	}

    void instruct()
    {
        while (true)
        {
            if (code.Length < i+1)
            {
                return;
            }
            char c = code[i];

            if (c == '#')
            {
                Set();
                i++;
                continue;
            }
            if (c == '~')
            {
                i++;
                System.Threading.Thread.Sleep(readI());
                i = i + 2;
                continue;
            }
            if (c == '$')
            {
                i++;
                object output=null;
                switch (GetType())
                {
                    case 1:
                        output = readI();
                        break;
                    case 2:
                        output = readS();
                        break;
                    case 3:
                        output = readB();
                        break;
                }
                i = i + 2;
                Console.WriteLine(output);
                continue;

            }
            //loops
            if (c == '[')
            {
                i++;
                if (code[i] == '(')
                {
                    i++;
                    if (readB())
                    {
                        i = i + 2;
                        instruct();
                        continue;
                    }
                    else
                    {
                        while (code[i] != ']')
                        {
                            i++;
                        }
                        i=i+2;
                        if (code[i] == '[' && code[i + 1] != '(')
                        {
                            instruct();
                            continue;
                        }
                    }
                }
                else
                {
                    while (code[i] != ']')
                    {
                        i++;
                    }
                    i++;
                    continue;
                }
            }
            if (c == ']')
            {
                i++;
                return;
            }
        }
    }

    //functions
    void Set()
    {
        i++;
        int read = readI();
        i++;
        int type = GetType();
        object value;
        switch (type)
        {
            case 1:
                M.i[read]=readI();
                break;
            case 2:
                M.s[read] = readS();
                break;
            case 3:
                M.b[read] = readB();
                break;
        }
        i++;

    }

    //reading
    int GetType()
    {
        if (code[i] == '^')
        {
            return 1;//int
        }
        if (code[i] == '"')
        {
            return 2;//string
        }
        if (code[i] == '=')
        {
            return 3;//bool
        }
        return 0;
    }
    string readS()
    {
        i++;
        char c = code[i];
        if (c == '?')
        {
            i++;
            string v=M.s[readI()];
            i++;
            return v;
        }
        if (c == '!')
        {
            i++;
            return st[new Random().Next(st.Length)].ToString();
        }
        if(st.Contains(c.ToString()))
        {
            string v ="";
            while (st.Contains(code[i].ToString()))
            {
                v = v + code[i];
                i++;
            }
            return v;
        }
        if (c == '+')
        {
            string v = "";
            i++;
            switch (GetType())
            {
                case 1:
                    v = v + readI().ToString();
                    break;
                case 2:
                    v = v + readS();
                    break;
                case 3:
                    v = v + readB().ToString();
                    break;
            }
            i++;
            switch (GetType())
            {
                case 1:
                    v = v + readI().ToString();
                    break;
                case 2:
                    v = v + readS();
                    break;
                case 3:
                    v = v + readB().ToString();
                    break;
            }
            i++;
            return v;
        }
        return "X";
    }
    int readI()
    {
        i++;
        char c = code[i];
        if (c == '?')
        {
            i++;
            int v = M.i[readI()];
            i++;
            return v;
        }
        if (c == '!')
        {
            i++;
            int v1 = readI();
            i++;
            int v2 = readI();
            i++;
            return new Random().Next(v1,v2);
        }
        if (char.IsDigit(c))
        {
            string v = "";
            while (char.IsDigit(code[i]))
            {
                v = v + code[i].ToString();
                i++;
            }
            return Convert.ToInt16(v);
        }
        if (c == '+')
        {
            int v = 0;
            i++;
            v = readI();
            i++;
            v = v + readI();
            i++;
            return v;
        }
        if (c == '*')
        {
            int v = 0;
            i++;
            v = readI();
            i++;
            v = v * readI();
            i++;
            return v;
        }
        if (c == '/')
        {
            int v = 0;
            i++;
            v = readI();
            i++;
            v = v / readI();
            i++;
            return v;
        }
        if (c == '-')
        {
            int v = 0;
            i++;
            v = readI();
            i++;
            v = v - readI();
            i++;
            return v;
        }
        return 0;
    }
    bool readB()
    {
        i++;
        char c = code[i];
        if (c == '?')
        {
            i++;
            bool v = M.b[readI()];
            i++;
            return v;
        }
        if (c == '!')
        {
            i++;
            if (new Random().Next(2) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (c=='0')
        {
            i++;
            return false;
        }
        if (c == '1')
        {
            i++;
            return true;
        }
        if (c == '>')
        {
            i++;
            int v1 = readI();
            i++;
            int v2 = readI();
            if (v1 > v2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (c == '<')
        {
            i++;
            int v1 = readI();
            i++;
            int v2 = readI();
            if (v1 < v2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (c == '<')
        {
            i++;
            switch (GetType()) {
                case 1:
                    int I1 = readI();
                    i++;
                    int I2 = readI();
                    if (I1 == I2) return true;
                    else return false;
                case 2:
                    string S1 = readS();
                    i++;
                    string S2 = readS();
                    if (S1 == S2) return true;
                    else return false;
                case 3:
                    bool B1 = readB();
                    i++;
                    bool B2 = readB();
                    if (B1 == B2) return true;
                    else return false;
            }

        }
        return false;
    }
}
