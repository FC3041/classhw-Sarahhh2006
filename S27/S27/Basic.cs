// based on the test it doesnt have new or creating obj => sttaic class 

public static class Basic {

    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
}
}
