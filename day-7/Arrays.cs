using System.Collections;
using System.Globalization;

class Arrays
{
    public static void display()
    {
        int[] num={1,2,3,4,5};
        Array.Clear(num,2,2);

        int total=0;
        Console.WriteLine("num:");
        foreach(int it in num)
        {
            Console.WriteLine(it);
            total+=it;
        }
        Console.WriteLine("div:"+total/(double)num.Length);

        int[,] matrix =
        {
            {1,2,5},
            {3,4,8}
        };
        // foreach(int it in matrix)
        // {
        //     Console.Write(it+" ");
        // }

        for(int i=0; i < matrix.GetLength(0); i++)
        {
            for(int j=0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j]+" ");
            }
            Console.WriteLine();
        }

        int[][] jagged = new int[2][];
        jagged[0]= new int[]{1,2};
        jagged[1]= new int[]{3,4,5,6};
        Console.WriteLine("Jagged");

        // foreach(int[] it in jagged)
        // {
        //     foreach(int x in it)
        //     {
        //         Console.Write(x+" ");
        //     }
        //     Console.WriteLine();
        // }

        for(int i = 0; i < jagged.GetLength(0); i++)
        {
            for(int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write(jagged[i][j]+" ");
            }
            Console.WriteLine();
        }


        //Copy
        int[] src = {1,2,3};
        int[] dest = new int[3];
    
        Array.Copy(src,dest,1);
        foreach(int it in dest)
        {
            Console.Write(it+" ");
        }
        Console.WriteLine();

        Array.Copy(src,dest,2);
        for(int i=0;i<3;i++)
        {
            Console.Write(dest[i]+" ");
        }
        Console.WriteLine();
       
        Array.Copy(src,dest,3);
        foreach(int it in dest)
        {
            Console.Write(it+" ");
        }
        Console.WriteLine();


        //Resize
        Console.WriteLine("ReSize");
        int[] nums={1,2};
        int[] nums1={0,2,4,1,7,1};
        Array.Resize(ref nums,4);
        // Array.Resize(nums,1);
        Array.Resize(ref nums,1);
        foreach(int it in nums)
        {
            Console.Write(it+" ");
        }
        Console.WriteLine();

        int idx=Array.IndexOf(nums1,1);
        Console.WriteLine(idx);

        bool found =Array.Exists(nums1,x=>x>7);
        bool found2 =Array.Exists(nums1,x=>x>6);
        Console.WriteLine(found);
        Console.WriteLine(found2);


        //List
         Console.Write("List:");
        List<int> number=new List<int>();
        number.Add(1);
        number.Add(3);
        number.Add(5);

        foreach(int it in number)
        {
            Console.Write(it+" ");
        }
        Console.WriteLine();
        Console.Write("ArrayList:");



        ArrayList list = new ArrayList();
        list.Add(9);
        list.Add("Ritik");

        foreach(var it in list)
        {
            Console.Write(it+" ");
        }
        Console.WriteLine();


        //stack
        Stack stack = new Stack();
        stack.Push("Ritik");
        stack.Push(112);

        Stack<int> st = new Stack<int>();
        st.Push(1);
        st.Push(2);
        st.Push(3);
        st.Pop();

        //queue
        Queue queue=new Queue();
        queue.Enqueue("ritik");
        queue.Enqueue(1);

        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());

        Queue<int> q=new Queue<int>();
        q.Enqueue(12);
        q.Enqueue(13);

        Console.WriteLine(q.Dequeue());
        Console.WriteLine(q.Dequeue());


        //Dictionary
        Dictionary<int, string> dict= new Dictionary<int, string>();
        dict.Add(1, "One");
        dict.Add(2,"ritik");
        Console.WriteLine(dict[1]);//one
        dict[1]="Roman";
        Console.WriteLine(dict[1]);//Roman
        foreach(KeyValuePair<int,string> emp in dict) 
        {
            Console.WriteLine(emp.Key +"->"+emp.Value);
        }


        
        Console.WriteLine("SortedList");
        SortedList<string, string> lists= new SortedList<string, string>();

        lists.Add("B","b");
        lists.Add("A","a");

        var desc=lists.Reverse();


        foreach(var li in desc) 
        {
            Console.WriteLine(li);
        }


        int[] arr = {1, 2, 3, 2, 1, 4, 2};
        Dictionary<int,int> freq=new Dictionary<int, int>();
        for(int i = 0; i < arr.Length; i++)
        {
            // freq[arr[i]]++;
            if (!freq.ContainsKey(arr[i]))
            {
                freq.Add(arr[i],1);
            }
            else
            {
                freq[arr[i]]++;
                
            }
        }
        foreach(var fq in freq)
        {
            Console.WriteLine(fq);
        }

        int[] arr1 = {1, 3, 5};
        int[] arr2 = {2, 4, 6};
        List<int> res= new List<int>();

        int ii=0;
        int jj=0;
        int n=arr1.Length;
        int m=arr2.Length;
        while(ii<n && jj < m)
        {
            if (arr1[ii] > arr2[jj])
            {
                res.Add(arr2[jj]);
                jj++;
            }
            else if(arr1[ii]<arr2[jj])
            {
                res.Add(arr1[ii]);
                ii++;
                
            }
            else
            {
                res.Add(arr1[ii++]);
                res.Add(arr2[jj++]);
            }

        }

        while(ii < n)
        {
            res.Add(arr1[ii++]);
        }
        while(jj < m)
        {
            res.Add(arr2[jj++]);
        }
        Console.WriteLine("Output");
        foreach(int it in res)
        {
            Console.Write(it+" ");
        }
        Console.WriteLine();

    }
}