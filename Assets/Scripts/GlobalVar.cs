using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVar
{
    private static GlobalVar instance;
    private GlobalVar() {}
    public static GlobalVar Instance() {
        if (instance == null) {
            instance = new GlobalVar();
        }
        return instance;
    }
    public int coin { get; private set; } = 0;

    public void AddCoin(int c) {
        coin += c;
        if (coin < 0) coin = 0;
    }
}
