public class SingLeton1//单线程

{

    private static SinglLeton singleton = null;

    private SingLeton1()

    {

    }

    public static SingLeton1 getsingleton()

    {

        if (singleton == null)

        {

            SingLeton1 singleton = new SingLeton1();

        }

        return singleton;

    }

}
public class SingLeton//多线程

{

     private static SinglLeton singleton=null; 

     private static raedonly object lockS=new object();//确保线程同步

      private SingLeton()

     {

     }

    public static SingLeton getsingleton()

   { 

     if(singleton==null)

        lock(lockS)

       {

           if(singleton==null)

           {

                SingLeton singleton=new  SingLeton();

           }

      }

    }

       return singleton;

   }

}