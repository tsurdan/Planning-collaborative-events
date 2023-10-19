using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.ProviderBase;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Drawing;


public partial class List : System.Web.UI.Page
{
    //פעולת עזר להרחבת תוספות
    public string[] harchavaEzerTos(string[] arr1, int index)
    {
        string[] arr = new string[arr1.Length + 1];
        for (int i = 0; i < arr1.Length; i++)
        {
            arr[i] = arr1[i];
        }

        string nom = "";
        if (arr[index] != null && arr[index] != "")
            nom = getName(arr[index]);
        int count = 0;
        int sum = 0;
        double ach = 0;
        for (int i = index; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "" && getName(arr[i]) == nom)
            {
                sum += getKamut2(arr[i]);
                count++;
            }

        }
        ach = ((double)sum) / ((double)(count + 1));

        string name = nom;
        int[] sameMana = new int[arr.Length + 2];
        int c = 0;
        int m = index;
        Boolean ok = true;
        while (m < arr.Length && (arr[m] == null || arr[m] == ""))
            m++;
        while (ok && m < arr.Length && getName(arr[m]) == name)
        {
            sameMana[c] = getKamut2(arr[m]);
            m++;
            c++;
            if (m >= arr.Length || c >= sameMana.Length)
                ok = false;
            while (m < arr.Length && (arr[m] == null || arr[m] == "" || getName(arr[m]) != name))
                m++;
        }

        if (c == 1 && sumArr(sameMana) <= 1)
            return null;
        int afoe = -1;
        for (int k = 0; k < sameMana.Length; k++)
        {
            if (sameMana[k] == null || sameMana[k] == 0)
            {
                afoe = k;
                k = sameMana.Length;
            }
        }
        sameMana[afoe] = 0;
        int l = getMaxPlace(sameMana, afoe);
        while (sameMana[afoe] < Convert.ToInt32((int)(ach + 0.5)))
        {
            sameMana[afoe] = sameMana[afoe] + 1;
            sameMana[l] = sameMana[l] - 1;
            l = getMaxPlace(sameMana, afoe);

        }
        c = 0;
        string[] leha = new string[arr.Length + 3];//lehachzara
        for (int i = 0; i < sameMana.Length; i++)
        {
            if (sameMana[i] != null && sameMana[i] != 0)
            {
                leha[i] = "" + sameMana[i] + "X" + name;
                c = i;
            }

        }
        c++;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "" && getName(arr[i]) != name)
            {
                leha[c] = arr[i];
                c++;
            }
        }
      
        if (sumArr(leha) != sumArr(arr1))
            return null;

        if (countArr(leha) - 1 != countArr(arr1))
            return null;

        return leha;



    }

    //הרחבת תוספות מוסיפה מנה לתוספות ע"י הרחבה שלהן, כלומר חלוקה מחדש
    public string[] harchavaTos(string[] arr, string[] tos, Boolean isTos)
    {
        if (arr == null || tos == null || isTos == null)
        {
            return null;
        }


        string name = "";
        string[] names = new string[tos.Length];
        int cp = 0;
        string[] tmp = new string[tos.Length];
        string[] tmp1 = new string[tos.Length];
        int n = 0;
        int from = -1;
        double hig = 0;
        double shiv = 0;
        double min = 9999999;
        int index = -1;
        string[] arrTmp = new string[arr.Length];
        string[] arrTmpSaver = new string[arr.Length];
        string[] tmpSaver = new string[arr.Length];
        int cou1 = 0;
        int cou2 = 0;
        int j = -1;
        Boolean ok = true;
        for (int i = 0; i < arr.Length; i++)
        {
            arrTmp[i] = arr[i];
        }
        int[] normaltos = getNormal(tos);
        int[] normal = getNormal(arr);

        while (n < tos.Length && (tos[n] == null || tos[n] == ""))
        {
            n++;
        }


        while (n < tos.Length)
        {
            cou1 = 0;
            cou2 = 0;
            arrTmp = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arrTmp[i] = arr[i];
            }

            ok = true;
            if (tos[n] != null && tos[n] != "")
            {
                name = getName(tos[n]);//co
                names[cp] = name;
                cp++;


                if (harchavaEzerTos(tos, n) != null)
                {


                    tmp = harchavaEzerTos(tos, n);

                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] != null && arr[i] != "")
                            cou1++;//5
                    }
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (tmp[i] != null && tmp[i] != "")
                            cou2++;//5
                    }
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (tmp[i] != null && tmp[i] != "")
                        {
                            from = i;
                            i = tmp.Length;
                        }

                    }
                    while (arrTmp.Length - cou1 < cou2)
                    {
                        arrTmp = addCell(arrTmp, 1);
                        normal = addCell(normal, 1);
                    }

                    j = from;//1



                    for (int i = cou1; i < arrTmp.Length; i++)
                    {
                        if (j < tmp.Length && tmp[j] != null && tmp[j] != "")
                        {
                            arrTmp[i] = tmp[j];
                            tmp[j] = null;
                            cou1++;
                            normal = getNormal(arrTmp);
                            normaltos = getNormal(tmp);
                        }
                        while (j < tmp.Length && (tmp[j] == null || tmp[j] == ""))
                        {
                            j++;
                        }

                    }

                    if (tmp.Length > arrTmp.Length)
                        arrTmp = addCell(arrTmp, tmp.Length - arrTmp.Length);
                    else
                        if (arrTmp.Length > tmp.Length)
                            tmp = addCell(tmp, arrTmp.Length - tmp.Length);

                    for (int i = 0; i < cou2; i++)
                    {

                        tmp1 = tisfut(arrTmp, tmp, true);
                        arrTmp = tisfut(arrTmp, tmp, false);
                        tmp = tmp1;


                    }

                    if (tmp == null)
                        return null;
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (i < arrTmp.Length && arrTmp[i] != null && tmp[i] != null && getName(arrTmp[i]) == getName(tmp[i]))
                            ok = false;
                    }
                    if (ok)
                    {
                        if (tmp.Length < arrTmp.Length)
                            tmp = addCell(tmp, arrTmp.Length - tmp.Length);
                        if (arrTmp.Length < tmp.Length)
                            arrTmp = addCell(arrTmp, tmp.Length - arrTmp.Length);
                        shiv = rateShivion(arrTmp, tmp);
                        hig = rateHigaion(arrTmp, normal, tmp, getNormal(tmp));
                        min = Math.Min(min, hig + shiv);
                        if (min == hig + shiv)
                        {
                            index = n;
                            arrTmpSaver = arrTmp;
                            tmpSaver = tmp;
                        }

                    }

                    while (n < tos.Length && (tos[n] == null || tos[n] == "" || find(names, getName(tos[n])) != -1))
                    {
                        n++;
                    }

                }//
                else
                    n++;
            }
            else
                n++;


        }



        if (isTos)
            return tmpSaver;

        return arrTmpSaver;

    }




    public int sumArr(int[] arr)
    {
        int i = 0;
        int sum = 0;
        while (i < arr.Length && arr[i] != null)
        {
            sum += arr[i];
            i++;
        }
        return sum;
    }
    //סוכם את כלל המנות שיש במערך מנות מחולקות
    public int sumArr(string[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "")
                sum += getKamut2(arr[i]);
        }

        return sum;
    }

    //מחזיר את סכום המנות במנה יחידה. כולל תוספת
    public int sumMana(string[] lotos, string[] tos, string mana)
    {
        int sum = 0;
        for (int i = 0; i < lotos.Length; i++)
        {
            if (lotos[i] != null && lotos[i] != "" && getName(lotos[i]) == mana)
                sum += getKamut2(lotos[i]);
        }
        for (int i = 0; i < tos.Length; i++)
        {
            if (tos[i] != null && tos[i] != "" && getName(tos[i]) == mana)
                sum += getKamut2(tos[i]);
        }

        return sum;
    }

    public int find(string[] arr, string somthing)
    {

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == somthing)
                return i;

        }
        return -1;
    }


    //סופר את כמות המנות השונות במערך מנות
    public int countManot(string[] arr)
    {
        string[] shemot = new string[arr.Length];
        int c = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "")
            {
                if (find(shemot, getName(arr[i])) == -1)
                {
                    shemot[c] = getName(arr[i]);
                    c++;
                }

            }

        }

        return countArr(shemot);
    }
    public int countArr(string[] arr)
    {
        int counter = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "")
                counter++;

        }
        return counter;
    }

    public string[] addCell(string[] arr, int plus)
    {
        string[] leha = new string[arr.Length + plus];
        for (int i = 0; i < arr.Length; i++)
        {
            leha[i] = arr[i];
        }
        return leha;
    }
    public string[] minusCell2(string[] arrt, int from)
    {
        string[] leha = new string[arrt.Length];
        for (int i = 0; i < from; i++)
            leha[i] = arrt[i];
        for (int i = from + 1; i < arrt.Length; i++)
            leha[i - 1] = arrt[i];
        return leha;
    }
    public int[] addCell(int[] arr, int plus)
    {
        int u = 0;
        int[] leha = new int[arr.Length + plus];
        for (int i = 0; i < arr.Length; i++)
        {
            leha[i] = arr[i];
        }
        return leha;
    }
    //מוריד את התאים הריקים מאמצע המערך ומעבירם לסופו
    public string[] removeNull(string[] arr)
    {
        int j = 0;
        string[] leha = new string[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && getKamut2(arr[i]) != 0)
                leha[j] = arr[i];
            else
                if ((arr[i] == null || getKamut2(arr[i]) == 0) && i + 1 < arr.Length && arr[i + 1] != null)
                    j--;
            j++;

        }
        return leha;
    }
    public Boolean isIn(int[] arr, int par)
    {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == par)
                return true;
        return false;
    }
    public string[] removeCells(string[] arr, int leng)
    {

        string[] leha = new string[leng];
        for (int i = 0; i < leha.Length; i++)
        {
            leha[i] = arr[i];
        }
        return leha;
    }

    public string getName(string str)
    {

        return (str.Substring(str.IndexOf("X") + 1, (str.Length - str.IndexOf("X") - 1)));

    }
    public int getKamut2(string str)
    {

        return Convert.ToInt32(str.Substring(0, (str.IndexOf("X"))));


    }


    public double getKamut22(string str)
    {

        return Convert.ToDouble(str.Substring(0, (str.IndexOf("X"))));


    }
    public string getKaum2(string str)
    {
        int ind = Convert.ToInt32(Session["index1"]);
        ind++;
        string uom2 = "";
        for (int i = 0; i < ind; i++)
        {
            if (getName(str) == getNom(Convert.ToString(Session["" + i])))
            {
                uom2 = getKamutUom(Convert.ToString(Session["" + i]));
            }
        }
        return uom2;


    }


    public double getPrice2(string str)
    {
        int ind = Convert.ToInt32(Session["index1"]);
        ind++;
        double price2 = 0;
        for (int i = 0; i < ind; i++)
        {
            if (getName(str) == getNom(Convert.ToString(Session["" + i])))
            {
                price2 = Convert.ToDouble(getPrice(Convert.ToString(Session["" + i])));
            }
        }
        return price2;


    }

    public int getKh2(string str)
    {
        int ind = Convert.ToInt32(Session["index1"]);
        ind++;
        int kh2 = 0;
        for (int i = 0; i < ind; i++)
        {
            if (getName(str) == getNom(Convert.ToString(Session["" + i])))
            {
                kh2 = Convert.ToInt32(getKh(Convert.ToString(Session["" + i])));
            }
        }
        return kh2;


    }


    public int getKs2(string str)
    {
        int ind = Convert.ToInt32(Session["index1"]);
        ind++;
        int ks2 = 0;
        for (int i = 0; i < ind; i++)
        {
            if (getName(str) == getNom(Convert.ToString(Session["" + i])))
            {
                ks2 = Convert.ToInt32(getKs(Convert.ToString(Session["" + i])));
            }
        }
        return ks2;


    }

    public int getMinPlace(int[] arr, int wot)//with out this
    {
        int min = 9999999;
        int ret = -1;
        int lastMin = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != 0)
            {
                lastMin = min;
                min = Math.Min(min, arr[i]);
                if (min == arr[i])
                {
                    if (i == wot)
                        min = lastMin;
                    else
                        ret = i;

                }
            }
        }
        return ret;
    }

    public int getMaxPlace(int[] arr, int wot)//with out this
    {
        int max = -1;
        int ret = -1;
        int lastMax = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != 0)
            {
                lastMax = max;
                max = Math.Max(max, arr[i]);
                if (max == arr[i])
                {
                    if (i == wot)
                        max = lastMax;
                    else
                        ret = i;

                }
            }
        }
        return ret;
    }

    //מחזיר את דירוג השיוויון של חלוקה. כמה שיותר קטן יותר שיוויוני
    public double rateShivion(string[] arr1, string[] tos1)
    {
        string[] arr = new string[arr1.Length];
        for (int i = 0; i < arr1.Length; i++)
        {
            arr[i] = arr1[i];
        }
        string[] tos = new string[tos1.Length];
        for (int i = 0; i < tos1.Length; i++)
        {
            tos[i] = tos1[i];
        }
        string[] arrmlk = new string[arr.Length];//arr mesuder lefi koshi
        string[] tosmlk = new string[arr.Length];

        int cou = 0;
        double shiv = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "")
                cou++;
        }

        int couTmp = cou;
        int n = 0;
        int maxPlace = -1;
        while (couTmp > 0)
        {
            maxPlace = getMax(arr, tos, -1);
            arrmlk[n] = arr[maxPlace];
            tosmlk[n] = tos[maxPlace];
            arr[maxPlace] = null;
            tos[maxPlace] = null;
            arr = removeNull(arr);
            tos = minusCell2(tos, maxPlace);
            couTmp--;
            n++;
        }

        for (int i = 0; i < (int)cou / 2; i++)
        {
            shiv += rateKoshi(arrmlk[i], tosmlk[i]) - rateKoshi(arrmlk[cou - 1 - i], tosmlk[cou - 1 - i]);

        }
        return shiv;

    }
    //פעולת עזר לדירוג ההיגיון. מתאים את משקל הגיון המנה לקושי שלה
    public double getMekademKoshi(double koshi)
    {

        if (koshi >= 2 && koshi < 5)
            return 0.1;
        if (koshi >= 5 && koshi < 7)
            return 0.2;
        if (koshi >= 7 && koshi < 8)
            return 0.3;
        if (koshi >= 8 && koshi < 9)
            return 0.4;
        if (koshi >= 9 && koshi < 10)
            return 0.4;
        if (koshi >= 10 && koshi < 13)
            return 0.5;
        if (koshi >= 13 && koshi < 15)
            return 0.6;
        if (koshi >= 15 && koshi < 17)
            return 0.7;

        if (koshi >= 17 && koshi < 26)
            return 0.8;

        if (koshi >= 26 && koshi < 41)
            return 0.9;

        if (koshi >= 40)
            return 1;

        return 0.05;
    }

    //מחזיר את דירוג ההיגיון של החלוקה. כמה שיותר קטן החלוקה יותר הגיונית
    public double rateHigaion(string[] arr, int[] normal, string[] tos, int[] normaltos)
    {
        double hig = 0;
        double hm = 0;//hig mana
        double koshi = 0;
        double rk = 0;//rate koshi between 0-1 according to the koshi
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "")
            {
                hm = Math.Abs(getKamut2(arr[i]) - normal[i]);
                koshi = rateKoshi(arr[i], null);
                rk = getMekademKoshi(koshi);
                hm *= rk;
                hig += hm;
            }
            if (tos[i] != null && tos[i] != "")
            {
                hm = Math.Abs(getKamut2(tos[i]) - normaltos[i]);
                koshi = rateKoshi(tos[i], null);
                rk = getMekademKoshi(koshi);
                hm *= rk;
                hig += hm;
            }
        }
        return hig;
    }
    //פעולת עזר לקיצוץ
    public string[] kizuzEzer(string[] arr, int index)
    {
        string[] leha = new string[arr.Length];//lehachzara

        string name = "";
        if (index < arr.Length && index >= 0 && arr[index] != null && arr[index] != "")
            name = getName(arr[index]);
        else
            return leha;
        int[] sameMana = new int[arr.Length + 1];
        int c = 0;
        int m = index;
        Boolean ok = true;
        while (ok && m < arr.Length && arr[m] != null && arr[m] != "" && getName(arr[m]) == name)
        {
            sameMana[c] = getKamut2(arr[m]);
            m++;
            c++;
            if (m >= arr.Length || c >= sameMana.Length)
                ok = false;
        }
        if (c == 1)
            return null;
        int afoe = -1;
        int min = 999999999;
        for (int k = 0; k < c; k++)
        {
            min = Math.Min(min, sameMana[k]);
            if (min == sameMana[k])
            {
                afoe = k;
            }

        }
        int kamutk = sameMana[afoe];
        int l = getMinPlace(sameMana, afoe);
        while (sameMana[afoe] > 0)
        {
            sameMana[afoe] = sameMana[afoe] - 1;
            sameMana[l] = sameMana[l] + 1;
            l = getMinPlace(sameMana, afoe);
        }


        c = 0;


        ok = true;
        for (int n = 0; n < arr.Length; n++)
        {
            if (n == index)
            {
                while (ok && n < arr.Length && arr[n] != null && arr[n] != "" && getName(arr[n]) == name)
                {
                    if (n == afoe + index)
                    {
                        n++;
                        c++;
                    }
                    else
                    {
                        leha[n] = "" + sameMana[c] + "X" + getName(arr[n]);
                        n++;
                        c++;
                    }

                    if (n >= arr.Length || c >= sameMana.Length)
                        ok = false;

                }
                n--;

            }
            else
                leha[n] = arr[n];

        }

        leha = removeNull(leha);

        return leha;
    }
    //פעולה שמורידה מנה מהחלוקה ע"י חלוקה מחדש
    public string[] kizuz(string[] arr, int[] normal)
    {
        Boolean ok = false;
        string name = "";
        string[] tmp = new string[arr.Length];
        int n = 0;
        double hig = 0;
        double shiv = 0;
        double min = 9999999;
        int index = -1;
        string[] tos = new string[arr.Length];//stam maarch reik
        int[] normaltos = new int[arr.Length];//stam maarch reik
        while (n < arr.Length && arr[n] != null && arr[n] != "")
        {
            if (arr[n] != null && arr[n] != "")
                name = getName(arr[n]);
            if (kizuzEzer(arr, n) != null)
            {
                tmp = kizuzEzer(arr, n);//20
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (tmp[i] != null && tmp[i] != "")
                        ok = true;

                }
                if (!ok)
                    return arr;
                tos = new string[tmp.Length];
                shiv = rateShivion(tmp, tos);
                hig = rateHigaion(tmp, getNormal(tmp), tos, normaltos);
                min = Math.Min(min, hig + shiv);
                if (min == hig + shiv)
                    index = n;
                while (n < arr.Length && arr[n] != null && arr[n] != "" && getName(arr[n]) == name)
                {
                    n++;
                }
            }
            else
                n++;
        }
        return kizuzEzer(arr, index);

    }

    //פעולת עזר להרחבה
    public string[] harchavaEzer(string[] arr1, int index)
    {

        string[] arr = new string[arr1.Length + 1];
        for (int i = 0; i < arr1.Length; i++)
        {
            arr[i] = arr1[i];
        }

        string nom = "";
        if (arr[index] != null && arr[index] != "")
            nom = getName(arr[index]);
        int count = 0;
        int sum = 0;
        double ach = 0;
        for (int i = index; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "" && getName(arr[i]) == nom)
            {
                sum += getKamut2(arr[i]);
                count++;
            }

        }
        if (sum == count)
            return null;
        ach = ((double)sum) / ((double)(count + 1));

        string name = nom;
        int[] sameMana = new int[arr.Length + 2];
        int c = 0;
        int m = index;
        Boolean ok = true;
        while (ok && arr[m] != null && getName(arr[m]) == name)
        {
            sameMana[c] = getKamut2(arr[m]);
            m++;
            c++;
            if (m >= arr.Length || c >= sameMana.Length)
                ok = false;
        }
        if (c == 1 && sameMana[0] <= 1)
            return null;
        int afoe = -1;
        for (int k = 0; k < sameMana.Length; k++)
        {
            if (sameMana[k] == null || sameMana[k] == 0)
            {
                afoe = k;
                k = sameMana.Length;
            }
        }
        sameMana[afoe] = 0;
        int l = getMaxPlace(sameMana, afoe);
        while (sameMana[afoe] < Convert.ToInt32((int)(ach + 0.5)))
        {
            sameMana[afoe] = sameMana[afoe] + 1;
            sameMana[l] = sameMana[l] - 1;
            l = getMaxPlace(sameMana, afoe);

        }
        c = 0;
        string[] leha = new string[arr.Length + 2];//lehachzara
        Boolean woi = false;//was on index
        for (int n = 0; n < arr.Length; n++)
        {
            if (n == index)
            {
                woi = true;
                while (n < leha.Length && c < sameMana.Length && c <= m && sameMana[c] != null && sameMana[c] != 0)
                {

                    leha[n] = "" + sameMana[c] + "X" + name;
                    n++;
                    c++;

                }

                n--;//כדי לתקן את הפלוס המיותר שיעשה הפור
            }
            else
            {
                if (woi && n != 0)
                    leha[n] = arr[n - 1];
                else
                    leha[n] = arr[n];

            }


        }

        leha = removeNull(leha);
        return leha;



    }
    //מוסיפה מנה לחלוקה ע"י חלוקה מחדש
    public string[] harchava(string[] arr, int[] normal, string[] tos1, int[] normaltos1)
    {
        string name = "";
        string[] tmp = new string[arr.Length + 2];
        int n = 0;
        double hig = 0;
        double shiv = 0;
        double min = 9999999;
        int index = 0;
        string[] tos = new string[tos1.Length];
        for (int i = 0; i < tos1.Length; i++)
        {
            tos[i] = tos1[i];
        }
        int[] normaltos = new int[normaltos1.Length];
        for (int i = 0; i < normaltos1.Length; i++)
        {
            normaltos[i] = normaltos1[i];
        }

        while (n < arr.Length && arr[n] != null && arr[n] != "")
        {
            if (arr[n] != null && arr[n] != "")
                name = getName(arr[n]);
            if (harchavaEzer(arr, n) != null)
            {
                tmp = harchavaEzer(arr, n);
                tos = addCell(tos1, 3);
                normaltos = addCell(normaltos1, 2);
                if (tos.Length < tmp.Length)
                    tos = addCell(tos, tmp.Length - tos.Length);
                shiv = rateShivion(tmp, tos);
                hig = rateHigaion(tmp, getNormal(tmp), tos, normaltos);
                min = Math.Min(min, hig + shiv);
                if (min == hig + shiv)
                    index = n;
                while (n < arr.Length && arr[n] != null && arr[n] != "" && getName(arr[n]) == name)
                {
                    n++;
                }
            }
            else
                n++;

        }
        return harchavaEzer(arr, index);

    }


    //מחזיר את הקושי הכולל של מנה יחידה
    public double rateKoshi(string mana, string tos)
    {

        int ind = Convert.ToInt32(Session["index1"]);
        ind++;
        string name = "";
        double kamut = 9999999999999;
        if (mana != null && mana != "")
        {
            name = getName(mana);
            kamut = (double)getKamut2(mana);
        }
        string str = "";
        for (int i = 0; i < ind; i++)
        {
            if (getNom(Convert.ToString(Session["" + i])) == name)
                str = Convert.ToString(Session["" + i]);
        }
        if (str == "")
            return -1;

        double kh = (double)getKh(str);
        double ks = (double)getKs(str);
        double price = (double)getPrice(str);

        double rate = ((0.2 * kamut * price) + (0.5 * kh) + (0.3 * ks));

        if (tos != null && tos != "")
        {
            name = getName(tos);
            kamut = (double)getKamut2(tos);
            str = "";
            for (int i = 0; i < ind; i++)
            {
                if (getNom(Convert.ToString(Session["" + i])) == name)
                    str = Convert.ToString(Session["" + i]);
            }
            if (str == "")
                return -1;

            kh = (double)getKh(str);
            ks = (double)getKs(str);
            price = (double)getPrice(str);

            rate += ((0.2 * kamut * price) + (0.5 * kh) + (0.3 * ks));

        }

        return rate;
    }

    public string getNom(string str)
    {

        return Convert.ToString(str.Substring(0, (str.IndexOf(","))));

    }
    public string getKamut(string str)
    {

        return Convert.ToString(str.Substring(str.IndexOf(",") + 1, (str.IndexOf("*") - str.IndexOf(",") - 1)));


    }

    public double getPrice(string str)
    {


        return Convert.ToDouble(str.Substring(str.IndexOf("*") + 1, (str.IndexOf(";") - str.IndexOf("*") - 1)));


    }

    public int getKh(string str)
    {

        return Convert.ToInt32(str.Substring(str.IndexOf(";") + 1, (str.IndexOf(":") - str.IndexOf(";") - 1)));

    }

    public int getKs(string str)
    {

        return Convert.ToInt32(str.Substring(str.IndexOf(":") + 1, (str.IndexOf("|") - str.IndexOf(":") - 1)));

    }

    public double getKamutNum(string str)
    {
        string kaNum = "";
        string s = getKamut(str);
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '0' || s[i] == '1' || s[i] == '2' || s[i] == '3' || s[i] == '4' || s[i] == '5' || s[i] == '6' || s[i] == '7' || s[i] == '8' || s[i] == '9' || s[i] == '.')
                kaNum += s[i];
        }
        return Convert.ToDouble(kaNum);
    }

    public string getKamutUom(string str)
    {

        string kaNum = "";
        string kaUom = "";
        string s = getKamut(str);
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '0' || s[i] == '1' || s[i] == '2' || s[i] == '3' || s[i] == '4' || s[i] == '5' || s[i] == '6' || s[i] == '7' || s[i] == '8' || s[i] == '9' || s[i] == '.')
                kaNum += s[i];
            else
                kaUom += s[i];
        }
        return kaUom;
    }

    public int getMin2(string[] arr1, int after, int notthis, string notThatName, Boolean isToFilterSame, Boolean isToFilterSmall, int[] last)
    {
        int cou = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != null && arr1[i] != "")
            {
                cou++;
            }
        }
        string[] arr = new string[cou];
        string[] arrTos = new string[cou];
        for (int i = 0; i < cou; i++)
        {
            arr[i] = arr1[i];
        }


        double min = 9999999;
        int ret = -1;
        double lastMin = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "")
            {
                lastMin = min;
                min = Math.Min(min, rateKoshi(arr[i], arrTos[i]));
                if (min == rateKoshi(arr[i], arrTos[i]))
                {
                    if ((isIn(last, i)) || (after != -1 && arr[i] != null && arr[after] != null && arr[i] != "" && arr[after] != "" && arr[i] == arr[after] && i >= after) || (after != -1 && arr[i] != null && arr[after] != null && arr[i] != "" && arr[after] != "" && ((notThatName != "" && getName(notThatName) == getName(arr[i])) || i == after || (isToFilterSmall && rateKoshi(arr[i], arrTos[i]) < rateKoshi(arr[after], arrTos[after])) || (isToFilterSame && getName(arr[i]) == getName(arr[after])))) || i == notthis)
                    {
                        min = lastMin;
                    }

                    else
                        ret = i;

                }
            }
        }
        return ret;
    }

    public int getMin(string[] arr1, int after, Boolean isToFilterSame)
    {
        int cou = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != null && arr1[i] != "")
            {
                cou++;
            }
        }
        string[] arr = new string[cou];
        string[] arrTos = new string[cou];
        for (int i = 0; i < cou; i++)
        {
            arr[i] = arr1[i];
        }


        double min = 9999999;
        int ret = -1;
        double lastMin = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "")
            {
                lastMin = min;//k6
                min = Math.Min(min, rateKoshi(arr[i], arrTos[i]));
                if (min == rateKoshi(arr[i], arrTos[i]))
                {
                    if (after != -1 && arr[i] != null && arr[after] != null && arr[i] != "" && arr[after] != "" && (i == after || rateKoshi(arr[i], arrTos[i]) < rateKoshi(arr[after], arrTos[after]) || (isToFilterSame && getName(arr[i]) == getName(arr[after]))))
                    {
                        min = lastMin;    
                    }

                    else
                        ret = i;

                }
            }
        }
        return ret;
    }

    public int getMax(string[] arr, string[] arrTos, int after)
    {

        double max = -1;
        int ret = -1;
        double lastMax = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "")
            {
                lastMax = max;
                max = Math.Max(max, rateKoshi(arr[i], arrTos[i]));
                if (max == rateKoshi(arr[i], arrTos[i]))
                {
                    if (after != null && after != -1 && (i == after || rateKoshi(arr[i], arrTos[i]) > rateKoshi(arr[after], arrTos[after])))
                        max = lastMax;
                    else
                        ret = i;

                }
            }
        }
        return ret;
    }
    //מעביר מנה אחת מהלא-תוספות לתוספות
    public string[] tisfut(string[] arr1, string[] arrTos1, Boolean isTos)
    {

        if (arr1 == null)
            return null;

        string[] arr = new string[arr1.Length];
        string[] arrTos = new string[arrTos1.Length];
        string tosefet = "";
        string tosefet2 = "";
        Boolean bbt = false;
        for (int i = 0; i < arr1.Length; i++)
        {
            arr[i] = arr1[i];


        }
        for (int i = 0; i < arrTos1.Length; i++)
        {
            arrTos[i] = arrTos1[i];
        }

        Boolean ok = true;
        int index1 = getMin(arr, -1, false);
        int index2 = getMin(arr, index1, true);

        int index22 = -2;

        int ci2 = 0;
        int[] last2 = new int[arr.Length];
        for (int g = 0; g < last2.Length; g++)
            last2[g] = -1;
        last2[ci2] = index2;
        ci2++;
        last2[ci2] = index1;
        ci2++;
        while (ok && index2 != -1 && arrTos[index2] != null)
        {

            index2 = getMin2(arr, index2, -1, arr[index1], false, true, last2);
            last2[ci2] = index2;
            ci2++;
            if (index2 == -1)
                ok = false;

        }

        if (ok == false)
            return null;
        int ci22 = 0;
        int[] last22 = new int[arr.Length];
        for (int g = 0; g < last22.Length; g++)
            last22[g] = -1;
        last22[ci2] = index2;
        ci22++;
        last22[ci22] = index1;
        ci22++;
        tosefet = arr[index1];
        int[] stamReik = new int[arr.Length];
        if (arrTos[index1] != null)
        {
            bbt = true;
            index22 = getMin2(arr, index2, index1, arrTos[index1], false, false, last22);
            last22[ci22] = index22;
            ci22++;
            if (index22 == -1)
                ok = false;


            while (ok && index22 != -1 && arrTos[index22] != null)
            {
                index22 = getMin2(arr, index2, index1, arrTos[index1], false, false, last22);
                last22[ci22] = index22;
                ci22++;
                if (index22 == -1)
                    ok = false;
            }
            if (ok == false)
                return null;
        }



        arr[index1] = null;
        arr = removeNull(arr);

        if (index1 < index2)
            index2--;
        //^
        Boolean ok2 = false;
        if (bbt)
        {
            ok = false;
            tosefet2 = arrTos[index1];

            if (arrTos[index22] != null)
            {
                arrTos = minusCell2(arrTos, index1);
                ok2 = true;
            }
            arrTos[index22] = tosefet2;


            if (!ok2)
                arrTos = minusCell2(arrTos, index1);
            //the two rows after that comment theui original place is in the ^
            if (index1 < index22)
                index22--;//16
        }


        if (ok)
            arrTos = minusCell2(arrTos, index1);

        arrTos[index2] = tosefet;
        if (isTos)
            return arrTos;
        return arr;

    }

    //מחזיר מערך של הכמות הנורמלית להבאה המתואם למערך המנות המתקבל
    public int[] getNormal(string[] arr)
    {
        int[] normal = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != "")
            {
                normal[i] = Convert.ToInt32(Session["" + getName(arr[i])]);
            }
        }
        return normal;
    }
    //מתאים את התוספות לשינוי בלא-תוספות
    public string[] hatamatTosafot(string[] arr1, string[] arrt, string[] tos)
    {
        string[] arr = new string[arrt.Length];
        for (int i = 0; i < arr1.Length; i++)
            arr[i] = arr1[i];
        int inde = -1;
        for (int i = 0; i < arrt.Length; i++)
        {
            if (arr[i] != arrt[i])
                inde = i;
        }
        inde++;
        string[] leha = minusCell2(tos, inde);
        leha = addCell(leha, arrt.Length - leha.Length);
        return leha;
    }

    //במקרה שבו עדיף להחליף במיקומן של שתי תוספות. מבצע זאת
    public string[] hachlafatTos(string[] arr, string[] tos)
    {
        string[] leha = new string[tos.Length];
        string save = "";
        for (int i = 0; i < tos.Length; i++)
            leha[i] = tos[i];
        for (int i = 0; i < leha.Length; i++)
        {
            if (leha[i] != null && leha[i] != "")
            {
                for (int j = i + 1; j < leha.Length; j++)
                {
                    if ((arr[j] != null && arr[j] != "" && arr[i] != null && arr[i] != "" && leha[i] != null && leha[i] != "" && leha[j] != null && leha[j] != "" && leha[j] != leha[i] && getName(leha[j]) != getName(arr[i]) && getName(leha[i]) != getName(arr[j])) && ((rateKoshi(leha[j], null) < rateKoshi(leha[i], null) && rateKoshi(arr[j], null) < rateKoshi(arr[i], null)) || (rateKoshi(leha[i], null) < rateKoshi(leha[j], null) && rateKoshi(arr[i], null) < rateKoshi(arr[j], null))))
                    {
                        save = leha[i];
                        leha[i] = leha[j];
                        leha[j] = save;
                    }
                    if (leha[j] == null && arr[j] != null && arr[j] != "" && leha[i] != null && leha[i] != "" && arr[j] != null && arr[j] != "" && arr[i] != null && arr[i] != "" && getName(leha[i]) != getName(arr[j]) && rateKoshi(arr[i], null) > rateKoshi(arr[j], null))
                    {
                        leha[j] = leha[i];
                        leha[i] = null;
                    }
                }
            }
        }
        return leha;
    }

    //מחזירה אמת אם המנה קיימת במסד הנתונים
    protected Boolean isExcitInData(string mana, string uom)
    {

        string myConnectionString = db.connectionString;
        string mySqlStr1 = "SELECT * FROM Manot WHERE Manot.NOM=@no AND Manot.UOM=@uo";
        SqlConnection mySqlConnection = new SqlConnection(myConnectionString);
        SqlCommand myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);

        SqlParameter q1 = new SqlParameter();
        q1.ParameterName = "@no";
        q1.SqlDbType = SqlDbType.VarChar;
        q1.Value = mana;

        SqlParameter q2 = new SqlParameter();
        q2.ParameterName = "@uo";
        q2.SqlDbType = SqlDbType.VarChar;
        q2.Value = uom;

        myCommandObj1.Parameters.Add(q1);
        myCommandObj1.Parameters.Add(q2);
        myCommandObj1.Connection.Open();
        SqlDataReader reader = myCommandObj1.ExecuteReader();


        while (reader.Read())
        {
            return true;
        }
        reader.Close();
        myCommandObj1.Connection.Close();
        return false;
    }

    //פעולת עזר למתכנת. מגרילה קלט
    public void randomSesssions(int seed)
    {
        //3

        Random rnd = new Random(seed);
        int nop2 = rnd.Next(2, 70);
        Session["nop1"] = nop2;
        int ind2 = rnd.Next(1, 60);
        Session["index1"] = ind2 - 1;

        string[] letters = new string[53];
        letters[0] = ""; letters[1] = "a"; letters[2] = "b"; letters[3] = "c"; letters[4] = "d"; letters[5] = "e"; letters[6] = "f"; letters[7] = "g"; letters[8] = "h"; letters[9] = "i"; letters[10] = "j"; letters[11] = "k"; letters[12] = "l"; letters[13] = "m"; letters[14] = "n"; letters[15] = "o"; letters[16] = "p"; letters[17] = "q"; letters[18] = "r"; letters[19] = "s"; letters[20] = "t"; letters[21] = "u"; letters[22] = "v"; letters[23] = "w"; letters[24] = "x"; letters[25] = "y"; letters[26] = "z"; letters[27] = "A"; letters[28] = "B"; letters[29] = "C"; letters[30] = "D"; letters[31] = "E"; letters[32] = "F"; letters[33] = "G"; letters[34] = "H"; letters[35] = "I"; letters[36] = "J"; letters[37] = "K"; letters[38] = "L"; letters[39] = "M"; letters[40] = "N"; letters[41] = "O"; letters[42] = "P"; letters[43] = "Q"; letters[44] = "R"; letters[45] = "S"; letters[46] = "T"; letters[47] = "U"; letters[48] = "V"; letters[49] = "W"; letters[50] = "X"; letters[51] = "Y"; letters[52] = "Z";
        string[] lett = new string[52];
        for (int i = 0; i < lett.Length; i++)
            lett[i] = letters[i + 1];

        for (int i = 0; i < ind2; i++)
        {
            string nom = "";
            int nomLeng = rnd.Next(2, 15);
            for (int j = 0; j < nomLeng; j++)
            {
                nom += lett[rnd.Next(0, 52)];
            }
            string kamut = "" + (rnd.Next(1, 101));
            int uomNumber = rnd.Next(1, 11);
            string uom = "";
            if (uomNumber == 1)
                uom = "kg";
            else
                uom = "units";
            double pfo = ((double)rnd.Next(1, 15000)) / ((double)rnd.Next(1, 990));
            string kh = "" + rnd.Next(1, 11);
            string ks = "" + rnd.Next(1, 11);
            string norm = "";
            if (!isExcitInData(nom, uom))
                norm = "" + rnd.Next(1, 101);

            Session["" + i] = "" + nom + "," + kamut + uom + "*" + pfo + ";" + kh + ":" + ks + "|" + norm;
        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //מציג את הדף בלי לעבור שוב על כל הקוד בכל פוסט בק
        if(IsPostBack)
        {
            tbs = (TextBox[])Session["tbs1"];
            tbn = (TextBox[])Session["tbn1"];
            Table table = new Table();
            Label l1g = new Label();
            Label l2g = new Label();
            l1g.Text = "Name:";
            l2g.Text = "What He Brings:";
            TableRow tr1g = new TableRow();
            TableCell tc11g = new TableCell();
            TableCell tc22g = new TableCell();
            tc11g.Controls.Add(l1g);
            tc22g.Controls.Add(l2g);
            tr1g.Controls.Add(tc11g);
            tr1g.Controls.Add(tc22g);
            table.Controls.Add(tr1g);
            for(int i=0; i<tbs.Length; i++)
            {
                TableRow trg = new TableRow();
                TableCell tc1g = new TableCell();
                TableCell tc2g = new TableCell();
                tc1g.Controls.Add(tbn[i]);
                tc2g.Controls.Add(tbs[i]);
                trg.Controls.Add(tc1g);
                trg.Controls.Add(tc2g);
                table.Controls.Add(trg);
            }
            this.div1.Controls.Add(table);

            LinkButton lbg = new LinkButton();
            lbg.Text = "You added a new dish that the site didn't recognize. Would you like to add allergens to the dish? (optional)";
            lbg.Click += lbOC;
            div2.Controls.Add(lbg);


            Button btng = new Button();
            btng.ID = "0";
            btng.Text = "Check";
            btng.Click += btnOC;
            btng.UseSubmitBehavior = false;
            btng.BackColor = Color.FromName("RoyalBlue");
            btng.Height = 40;
            btng.Width = 60;
            btng.BorderColor = Color.FromName("White");
            btng.ForeColor = Color.FromName("White");
            this.div1.Controls.Add(btng);

            Button btn3g = new Button();
            btn3g.ID = "11";
            btn3g.Text = "Save";
            btn3g.Click += submitOC;
            btn3g.UseSubmitBehavior = false;
            btn3g.BackColor = Color.FromName("RoyalBlue");
            btn3g.Height = 40;
            btn3g.Width = 60;
            btn3g.BorderColor = Color.FromName("White");
            btn3g.ForeColor = Color.FromName("White");
            this.div1.Controls.Add(btn3g);

            Session["tbs1"] = tbs;
            Session["tbn1"] = tbn;


            return;
        }
        //עד לפה0
        if (Convert.ToInt32(Request.QueryString["mas"]) != 3)
            Response.Redirect("Login.aspx");
        int ind = Convert.ToInt32(Session["index1"]);
        ind++;

        string[] bfh = new string[ind];
        for (int i = 0; i < ind; i++)
        {
            bfh[i] = Convert.ToString(Session["" + i]);
        }
        if ((int)((((double)ind) / ((double)2)) + 0.5) > Convert.ToInt32(Session["nop1"]))
            Response.Redirect("Login.aspx");

        //נותן מערך (נורמל1) שמתואם לסשן ובו הכמות הממוצעת הנורמלית של כל מנה בחלוקה.. לפי מסד הנתונים

        double[] normal1 = new double[ind];

        for (int j = 0; j < ind; j++)
        {
            string mana1 = Convert.ToString(Session["" + j]);
            string name1 = getNom(mana1);
            string uom1 = getKamutUom(mana1);

            string myConnectionString = db.connectionString;
            string mySqlStr1 = "SELECT * FROM Manot WHERE Manot.NOM=@no AND Manot.UOM=@uo ";
            SqlConnection mySqlConnection = new SqlConnection(myConnectionString);
            SqlCommand myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


            SqlParameter q1 = new SqlParameter();
            q1.ParameterName = "@no";
            q1.SqlDbType = SqlDbType.VarChar;
            q1.Value = name1;
            myCommandObj1.Parameters.Add(q1);


            SqlParameter q2 = new SqlParameter();
            q2.ParameterName = "@uo";
            q2.SqlDbType = SqlDbType.VarChar;
            q2.Value = uom1;
            myCommandObj1.Parameters.Add(q2);
            myCommandObj1.Connection.Open();
            SqlDataReader reader = myCommandObj1.ExecuteReader();
            double sum = 0;
            double counter = 0;
            while (reader.Read())
            {

                string myConnectionString2 = db.connectionString;
                string mySqlStr12 = "SELECT * FROM Past WHERE Past.MANA=@idd OR Past.MANATOS=@idd ";
                SqlConnection mySqlConnection2 = new SqlConnection(myConnectionString2);
                SqlCommand myCommandObj12 = new SqlCommand(mySqlStr12, mySqlConnection2);


                SqlParameter q12 = new SqlParameter();
                q12.ParameterName = "@idd";
                q12.SqlDbType = SqlDbType.Int;
                q12.Value = reader["id"];
                myCommandObj12.Parameters.Add(q12);

                myCommandObj12.Connection.Open();
                SqlDataReader reader2 = myCommandObj12.ExecuteReader();

                while (reader2.Read())
                {
                    if (Convert.ToString(reader["id"]) == Convert.ToString(reader2["MANA"]))
                    {
                        sum += Convert.ToInt32(reader2["KAMUT"]);
                        counter++;
                    }

                    else
                        if (Convert.ToString(reader["id"]) == Convert.ToString(reader2["MANATOS"]))
                        {
                            sum += Convert.ToInt32(reader2["KAMUTTOS"]);
                            counter++;
                        }


                }
                reader2.Close();
                myCommandObj12.Connection.Close();
            }
            if (counter != 0)
                normal1[j] = sum / counter;

            reader.Close();
            myCommandObj1.Connection.Close();

        }
        //עד לפה1



        // בכל תא ריק במערך מקודם של הכמות הממוצעת של המנות בחלוקות העבר, שם את הכמות הממוצעת הנורמלית שקובלה מהמשתמש. מדובר במנות חדשות
        int nop = Convert.ToInt32(Session["nop1"]); //num of people
        if (!IsPostBack)
            Session["newMana1"] = "";
        double c1 = 0;
        double c2 = 0;
        double sumKamut = 0;
        double sumAv = 0;
        double noh = 0;// num of halukot
        for (int h = 0; h < ind; h++)
        {

            if (normal1[h] != null && normal1[h] != 0)
            {
                sumKamut += getKamutNum(Convert.ToString(Session["" + h]));
                c1++;

                sumAv += normal1[h];
                c2++;
            }
        }
        if (sumAv != 0 && c2 != 0)
            noh = (sumKamut / c1) / (sumAv / c2);
        for (int g = 0; g < ind; g++)
        {
            if (normal1[g] != null && normal1[g] == 0)
            {
                if (!IsPostBack)
                    Session["newMana1"] += "" + g + ";";
                // normal1[g] = (getKamutNum(Convert.ToString(Session["" + g])) / noh);
                string str = Convert.ToString(Session["" + g]);
                normal1[g] = Convert.ToInt32(str.Substring(str.IndexOf("|") + 1, (str.Length) - str.IndexOf("|") - 1));
            }
        }
        //עד לפה2


        //ממיר את הכמות הממוצעת למספרים שלמים. שם את המערך גם בסשן לשימוש עתידי.

        int high = Convert.ToInt32(40 * nop);
        string stam1 = "width: 552px;" + "height:" + high + "px" + "; margin-left: 350px;background-color:white; ";
        div1.Style.Add("st1", stam1);


        string[] manotlm = new string[ind]; //manot lo mechulakot
        int[] normallm = new int[ind];

        for (int i = 0; i < ind; i++)
        {
            string str = Convert.ToString(Session["" + i]);
            manotlm[i] = str;
            normallm[i] = Convert.ToInt32((int)(normal1[i] + 0.5));
        }
        for (int g = 0; g < ind; g++)
        {
            if (normallm[g] != null && normallm[g] != 0 && !IsPostBack)
            {
                Session["" + getNom(Convert.ToString(Session["" + g]))] = normallm[g];
            }
        }
        //עד לפה3




        //מחלק את המנות המבוקשות למערך לפי הכמות הנורמלית של כל מנה עכשיו זה מנה להבאה מנה להבאה במערך. לאו דווקא מתאים לכמות האנשים
        int avav = Convert.ToInt32((int)noh + 1);
        int len = (ind + 1) * avav * 2;
        int[] halu;
        string[] manot = new string[2];
        int[] normalq = new int[2];
        int cou = 0;
        for (int d = 0; d < ind; d++)
        {
            if (manotlm[d] != null && normallm[d] != null && getKamutNum(manotlm[d]) != 0 && normallm[d] != 0)
            {

                int kpl = Convert.ToInt32((int)((getKamutNum(manotlm[d]) / normallm[d]) + 0.5));//kama peamim lechalek
                if (kpl == 0)
                    kpl = 1;
                halu = new int[kpl];
                for (int fsd = 0; fsd < halu.Length; fsd++)
                {
                    halu[fsd] = normallm[d];
                }
                int inde = 0;

                while (sumArr(halu) > getKamutNum(manotlm[d]))
                {
                    if (inde >= halu.Length)
                        inde = 0;

                    halu[inde]--;
                    inde++;
                }

                while (sumArr(halu) < getKamutNum(manotlm[d]))
                {
                    if (inde >= halu.Length)
                        inde = 0;

                    halu[inde]++;
                    inde++;
                }



                for (int k = 0; k < halu.Length; k++)
                {
                    manot[cou] = "" + Convert.ToString(halu[k]) + "X" + getNom(manotlm[d]);
                    normalq[cou] = normallm[d];
                    cou++;
                    manot = addCell(manot, 1);
                    normalq = addCell(normalq, 1);
                }
            }



        }
        //עד לפה5


        //משווה את מספר המנות למספר האנשים על ידי הרחבה וקיצוץ, ובמקרים חריגים גם על ידי תספות
        cou += 2;
        Boolean takin = true;
        Boolean avad = false;
        Boolean lonull = false;
        Boolean bbk = false;//bikarty bekizuz
        Boolean bbkt = false;//bikarty bekizu- tisfut
        string[] lotos = new string[cou];//lo tosafot 
        string[] tos = new string[cou];//tosafot
        int[] normal = new int[cou];
        int[] normaltos = new int[cou];
        int cou1 = cou - 2;//lo tosafot
        int cou2 = 0;//tosafot
        string[] lotosTmp = new string[cou];
        string[] tosTmp = new string[cou];
        int[] normalTmp = new int[cou];
        int[] normaltosTmp = new int[cou];
        double shiv = 0;
        double hig = 0;
        double higTmp = 0;//higaion Temporary
        double shivTmp = 0;//shivion Temporary

        for (int h = 0; h < lotos.Length; h++)
        {
            lotos[h] = manot[h];
            normal[h] = normalq[h];
        }



        if (cou1 != nop)
        {
            if (takin && cou1 > nop)
            {
                bbk = true;
                if (countManot(lotos) == cou1)
                    takin = false;
                while (takin && cou1 > nop)
                {
                    lotosTmp = kizuz(lotos, normal);
                    normal = getNormal(lotosTmp);
                    lotos = lotosTmp;
                    cou1--;

                    if (countManot(lotos) == cou1)
                        takin = false;
                }
                if (cou1 > nop)
                    takin = false;
                double dcou1 = (double)cou1;
                dcou1 /= 2;
                dcou1 = (int)(dcou1 + 0.5);
                if (dcou1 > nop)
                    takin = false;

            }

            if (takin && nop > cou1)
            {
                while (takin && nop > cou1)
                {
                    lotosTmp = harchava(lotos, normal, tos, normaltos);
                    normal = getNormal(lotosTmp);
                    lotos = lotosTmp;
                    tos = new string[lotos.Length];
                    cou1++;
                }
                tos = new string[lotos.Length];
                if (nop > cou1)
                    takin = false;
            }
            if (tos.Length < lotos.Length)
                tos = addCell(tos, lotos.Length - tos.Length);
            shiv = rateShivion(lotos, tos);
            hig = rateHigaion(lotos, normal, tos, normaltos);

            cou1 = 0;
            for (int i = 0; i < lotos.Length; i++)
            {
                if (lotos[i] != null && lotos[i] != "")
                    cou1++;
            }




            while (bbk && cou1 > nop)
            {
                bbkt = true;
                lotosTmp = tisfut(lotos, tos, false);
                tos = tisfut(lotos, tos, true);
                lotos = lotosTmp;
                normal = getNormal(lotos);
                normaltos = getNormal(tos);
                cou2++;
                cou1--;
                if (tos.Length < lotos.Length)
                    tos = addCell(tos, lotos.Length - tos.Length);
                shiv = rateShivion(lotos, tos);
                hig = rateHigaion(lotos, normal, tos, normaltos);

            }

            if (bbkt && cou1 > cou2 && sumArr(tos) != cou2)
            {
                tosTmp = harchavaTos(lotos, tos, true);
                lotosTmp = addCell(lotos, tos.Length - lotos.Length);
                normalTmp = getNormal(lotosTmp);
                normaltosTmp = getNormal(tosTmp);
                if (tosTmp.Length < lotosTmp.Length)
                    tosTmp = addCell(tosTmp, lotosTmp.Length - tosTmp.Length);
                shivTmp = rateShivion(lotosTmp, tosTmp);
                higTmp = rateHigaion(lotosTmp, normalTmp, tosTmp, normaltosTmp);
                while (higTmp + shivTmp < hig + shiv && cou1 > cou2)
                {
                    lotos = lotosTmp;
                    tos = tosTmp;
                    cou2++;
                    normaltos = normaltosTmp;
                    normal = normalTmp;
                    hig = higTmp;
                    shiv = shivTmp;
                    if (harchavaTos(lotos, tos, true) != null)
                    {


                        tosTmp = harchavaTos(lotos, tos, true);
                        lotosTmp = addCell(lotos, tos.Length - lotos.Length);
                        normalTmp = getNormal(lotosTmp);
                        normaltosTmp = getNormal(tosTmp);
                        if (tosTmp.Length < lotosTmp.Length)
                            tosTmp = addCell(tosTmp, lotosTmp.Length - tosTmp.Length);
                        shivTmp = rateShivion(lotosTmp, tosTmp);
                        higTmp = rateHigaion(lotosTmp, normalTmp, tosTmp, normaltosTmp);
                    }

                }

            }

        }

        //עד לפה 6

        //משפר את החלוקה על ידי הרחבה תספות והרחבת תוספות החלפת תוספות ועוד. מקדם צעדים שמשפרים את הדירוגים
        lotos = removeCells(lotos, cou1 + 1);
        tos = removeCells(tos, lotos.Length);
        if (tos.Length < lotos.Length)
            tos = addCell(tos, lotos.Length - tos.Length);
        hig = rateHigaion(lotos, normal, tos, normaltos);
        shiv = rateShivion(lotos, tos);

        string[] lotosTmp1 = new string[lotos.Length];
        string[] lotosTmp2 = new string[lotos.Length];
        string[] tosTmp2 = new string[lotos.Length];
        int[] normalTmp2 = new int[lotos.Length];
        int[] normaltosTmp2 = new int[lotos.Length];
        double higTmp2 = 0;
        double shivTmp2 = 0;
        Boolean kubal = false;
        Boolean go = true;
        if (/*!bbkt &&*/ countArr(lotos) < sumArr(lotos) && countManot(lotos) > 1)
        {


            if (cou1 > cou2 && countManot(lotos) > 1)
            {


                if (harchava(lotos, normal, tos, normaltos) != null)
                {
                    lotosTmp = harchava(lotos, normal, tos, normaltos);//lo tosafot Temporary
                    if (!bbkt)
                        tosTmp = new string[lotosTmp.Length];//tosafot Temporary
                    else
                        if (lotosTmp.Length > tos.Length)
                            tosTmp = addCell(tos, lotosTmp.Length - tos.Length);
                        else
                            if (lotosTmp.Length < tos.Length)
                                tosTmp = removeCells(tos, lotosTmp.Length);
                    normalTmp = getNormal(lotosTmp);
                    normaltosTmp = getNormal(tosTmp);




                    if (tisfut(lotosTmp, tosTmp, true) != null)
                    {
                        lotosTmp1 = tisfut(lotosTmp, tosTmp, false);
                        tosTmp = tisfut(lotosTmp, tosTmp, true);
                        lotosTmp = lotosTmp1;
                        normalTmp = getNormal(lotosTmp);
                        normaltosTmp = getNormal(tosTmp);
                        if (tosTmp.Length < lotosTmp.Length)
                            tosTmp = addCell(tosTmp, lotosTmp.Length - tosTmp.Length);
                        higTmp = rateHigaion(lotosTmp, normalTmp, tosTmp, normaltosTmp);
                        shivTmp = rateShivion(lotosTmp, tosTmp);

                        
                        if (harchavaTos(lotosTmp, tosTmp, true) != null)
                        {

                            tosTmp2 = harchavaTos(lotosTmp, tosTmp, true);
                            lotosTmp2 = addCell(lotosTmp, tosTmp2.Length - lotosTmp.Length);
                            normalTmp2 = getNormal(lotosTmp2);
                            normaltosTmp2 = getNormal(tosTmp2);
                            if (tosTmp2.Length < lotosTmp2.Length)
                                tosTmp2 = addCell(tosTmp2, lotosTmp2.Length - tosTmp2.Length);
                            higTmp2 = rateHigaion(lotosTmp2, normalTmp2, tosTmp2, normaltosTmp2);
                            shivTmp2 = rateShivion(lotosTmp2, tosTmp2);

                            if (tosTmp2 != null && shivTmp2 + higTmp2 < shivTmp + higTmp)
                            {
                                kubal = true;
                                tosTmp = tosTmp2;
                                lotosTmp = lotosTmp2;
                                normalTmp = normalTmp2;
                                normaltosTmp = normaltosTmp2;
                                normalTmp = getNormal(lotosTmp);
                                normaltosTmp = getNormal(tosTmp);
                                higTmp = higTmp2;
                                shivTmp = shivTmp2;

                            }
                        }


                    }
                    else
                        go = false;
                }
                else
                    go = false;

            }
            else
                go = false;

            if (sumArr(lotosTmp) + sumArr(tosTmp) != sumArr(lotos) + sumArr(tos))
                go = false;
            int ig = 0;

            
            while (go && shivTmp + higTmp < shiv + hig)
            {
                lotos = lotosTmp;
                tos = tosTmp;
                if (kubal)
                    cou2++;
                cou2++;
                normaltos = normaltosTmp;
                normal = normalTmp;
                hig = higTmp;
                shiv = shivTmp;




                if (cou1 > cou2 && countManot(lotos) > 1)
                {


                    if (harchava(lotos, normal, tos, normaltos) != null)
                    {
                        lotosTmp = harchava(lotos, normal, tos, normaltos);//lo tosafot Temporary
                        tosTmp = hatamatTosafot(lotos, lotosTmp, tos);//tosafot Temporary
                        normalTmp = getNormal(lotosTmp);
                        normaltosTmp = getNormal(tosTmp);





                        if (tisfut(lotosTmp, tosTmp, true) != null)
                        {

                            lotosTmp1 = tisfut(lotosTmp, tosTmp, false);
                            tosTmp = tisfut(lotosTmp, tosTmp, true);
                            lotosTmp = lotosTmp1;
                            normalTmp = getNormal(lotosTmp);
                            normaltosTmp = getNormal(tosTmp);
                            if (tosTmp.Length < lotosTmp.Length)
                                tosTmp = addCell(tosTmp, lotosTmp.Length - tosTmp.Length);
                            higTmp = rateHigaion(lotosTmp, normalTmp, tosTmp, normaltosTmp);//higaion Temporary
                            shivTmp = rateShivion(lotosTmp, tosTmp);//shivion Temporary
                            if (harchavaTos(lotosTmp, tosTmp, true) != null)
                            {

                                tosTmp2 = harchavaTos(lotosTmp, tosTmp, true);

                                lotosTmp2 = addCell(lotosTmp, tosTmp2.Length - lotosTmp.Length);
                                normalTmp2 = getNormal(lotosTmp2);
                                normaltosTmp2 = getNormal(tosTmp2);
                                if (tosTmp2.Length < lotosTmp2.Length)
                                    tosTmp2 = addCell(tosTmp2, lotosTmp2.Length - tosTmp2.Length);
                                higTmp2 = rateHigaion(lotosTmp2, normalTmp2, tosTmp2, normaltosTmp2);
                                shivTmp2 = rateShivion(lotosTmp2, tosTmp2);

                                if (tosTmp2 != null && shivTmp2 + higTmp2 < shivTmp + higTmp)
                                {
                                    kubal = true;
                                    tosTmp = tosTmp2;
                                    lotosTmp = lotosTmp2;
                                    normalTmp = normalTmp2;
                                    normaltosTmp = normaltosTmp2;
                                    normalTmp = getNormal(lotosTmp);
                                    normaltosTmp = getNormal(tosTmp);
                                    higTmp = higTmp2;
                                    shivTmp = shivTmp2;

                                }
                                else
                                    kubal = false;

                            }
                            else
                                kubal = false;
                        }

                        else
                            go = false;
                    }
                    else
                        go = false;

                }
                else
                    go = false;

                if (sumArr(lotosTmp) + sumArr(tosTmp) != sumArr(lotos) + sumArr(tos))
                    go = false;

            }
            ig++;
            

        }


        if (lotos.Length < tos.Length)
            lotos = addCell(lotos, tos.Length - lotos.Length);
        else
            if (lotos.Length > tos.Length)
                tos = addCell(tos, lotos.Length - tos.Length);
        if (tos != null && countArr(tos) < sumArr(tos) && cou1 > cou2 && countManot(tos) >= 1)
        {
            if (tos.Length < lotos.Length)
                tos = addCell(tos, lotos.Length - tos.Length);
            hig = rateHigaion(lotos, getNormal(lotos), tos, getNormal(tos));
            shiv = rateShivion(lotos, tos);
            if (harchavaTos(lotos, tos, true) != null)
            {


                tosTmp = harchavaTos(lotos, tos, true);
                lotosTmp = addCell(lotos, tosTmp.Length - lotos.Length);
                normalTmp = getNormal(lotosTmp);
                normaltosTmp = getNormal(tosTmp);
                if (tosTmp.Length < lotosTmp.Length)
                    tosTmp = addCell(tosTmp, lotosTmp.Length - tosTmp.Length);
                higTmp = rateHigaion(lotosTmp, normalTmp, tosTmp, normaltosTmp);
                shivTmp = rateShivion(lotosTmp, tosTmp);

                while (tos != null && shivTmp + higTmp < shiv + hig)
                {
                    cou2++;
                    tos = tosTmp;
                    lotos = lotosTmp;
                    normal = normalTmp;
                    normaltos = normaltosTmp;
                    normal = getNormal(lotos);
                    normaltos = getNormal(tos);
                    hig = higTmp;
                    shiv = shivTmp;
                    if (tos != null && harchavaTos(lotos, tos, true) != null)
                        tosTmp = harchavaTos(lotos, tos, true);
                    lotosTmp = addCell(lotos, tosTmp.Length - lotos.Length);
                    normalTmp = getNormal(lotosTmp);
                    normaltosTmp = getNormal(tosTmp);
                    if (tosTmp.Length < lotosTmp.Length)
                        tosTmp = addCell(tosTmp, lotosTmp.Length - tosTmp.Length);
                    higTmp = rateHigaion(lotosTmp, normalTmp, tosTmp, normaltosTmp);
                    shivTmp = rateShivion(lotosTmp, tosTmp);

                }

            }
        }



        if (lotos.Length < tos.Length)
            lotos = addCell(lotos, tos.Length - lotos.Length);
        else
            if (lotos.Length > tos.Length)
                tos = addCell(tos, lotos.Length - tos.Length);

        tos = hachlafatTos(lotos, tos);
        normaltos = getNormal(tos);
        shiv = rateShivion(lotos, tos);
        //עד לפה7

       
        //מכניס את החלוקה ליבות טקסט בשביל ההצגה
        TextBox[] tbname = new TextBox[nop];
        TextBox[] tbmanotm = new TextBox[nop];
        for (int i = 0; i < nop; i++)
        {
            tbmanotm[i] = new TextBox();
            tbname[i] = new TextBox();
        }
        Table t = new Table();
        Label l1 = new Label();
        Label l2 = new Label();
        //   tbs = new TextBox[2];
        //  l1.Text = /*"Name:"*/"shiv:" + rateShivion(lotos, tos) + "old:" + rateHigaion2(lotos, normal, tos, normaltos);
        //  l2.Text = /*"What He Bring:"*/ "new:" + rateHigaion(lotos, normal, tos, normaltos);
        l1.Text = "Name:";
        l2.Text = "What He Brings:";
        TableRow tr1 = new TableRow();
        TableCell tc11 = new TableCell();
        TableCell tc22 = new TableCell();
        tc11.Controls.Add(l1);
        tc22.Controls.Add(l2);
        tr1.Controls.Add(tc11);
        tr1.Controls.Add(tc22);
        t.Controls.Add(tr1);
        for (int i = 0; i < nop; i++)
        {
            tbmanotm[i].Text += "" + lotos[i] + "+" + tos[i];
            TableRow tr = new TableRow();
            TableCell tc1 = new TableCell();
            TableCell tc2 = new TableCell();
            tc1.Controls.Add(tbname[i]);
            tc2.Controls.Add(tbmanotm[i]);
            tr.Controls.Add(tc1);
            tr.Controls.Add(tc2);
            t.Controls.Add(tr);
        }


        this.div1.Controls.Add(t);
        tbs = tbmanotm;
        tbn = tbname;
        
//עד לפה8



        //מוסיף קישור להוספת אלרגנים שנפתח במקרה של מנות חדשות. מוסיף את הכפתורים שמירה ובדיקה
        LinkButton lb = new LinkButton();
        lb.Text = "You added a new dish that the site didn't recognize. Would you like to add allergens to the dish? (optional)";
        lb.Click += lbOC;
        div2.Controls.Add(lb);


        Button btn = new Button();
        btn.ID = "0";
        btn.Text = "Check";
        btn.Click += btnOC;
        btn.UseSubmitBehavior = false;
        btn.BackColor = Color.FromName("RoyalBlue");
        btn.Height = 40;
        btn.Width = 60;
        btn.BorderColor = Color.FromName("White");
        btn.ForeColor = Color.FromName("White");
        this.div1.Controls.Add(btn);

        Button btn3 = new Button();
        btn3.ID = "11";
        btn3.Text = "Save";
        btn3.Click += submitOC;
        btn3.UseSubmitBehavior = false;
        btn3.BackColor = Color.FromName("RoyalBlue");
        btn3.Height = 40;
        btn3.Width = 60;
        btn3.BorderColor = Color.FromName("White");
        btn3.ForeColor = Color.FromName("White");
        this.div1.Controls.Add(btn3);

        Session["tbs1"] = tbs;
        Session["tbn1"] = tbn;
        //עד לפה9
    }



    public TextBox[] tbs;
    public TextBox[] tbn;
    //פועלת בלחיצה על כפתור הבדיקה. בודקת שכל המנות הרצויות נמצאות בחלוקה, גם לאחר עריכת המשתמש
    void btnOC(System.Object sender, EventArgs e)
    {
        int ind = Convert.ToInt32(Session["index1"]);
        ind++;
        string[] manot = new string[ind];

        string hod = "";
        int nop = Convert.ToInt32(Session["nop1"]);
        string[] manotAru = new string[nop];//manot aruchot
        int sum;
        int sumAr;

        for (int i = 0; i < manotAru.Length; i++)
        {
            manotAru[i] = tbs[i].Text.ToString();
        }
        string[] lotos = new string[nop];
        string[] tos = new string[nop];

        for (int i = 0; i < manotAru.Length; i++)
        {
            if (manotAru[i].IndexOf("+") == -1)
            {
                i = manotAru.Length;
                hod = "A wrong entry was entered. Preserve the string structure " + ".";
            }
            else
            {
                lotos[i] = manotAru[i].Substring(0, (manotAru[i].IndexOf("+")));
                if (manotAru[i].Length > manotAru[i].IndexOf("+") + 1)
                    tos[i] = manotAru[i].Substring(manotAru[i].IndexOf("+") + 1, (manotAru[i].Length - manotAru[i].IndexOf("+") - 1));
                if (lotos[i].IndexOf("X") == -1 || lotos[i].IndexOf("X") == 0|| (manotAru[i].Length > manotAru[i].IndexOf("+") + 1 && tos[i].IndexOf("X") == -1))
                {
                    i = manotAru.Length;
                    hod = "A wrong entry was entered. Preserve the string structure " + ".";
                }
            }

        }

        if (hod == "")
        {

            for (int i = 0; i < ind; i++)
            {
                if (Convert.ToString(Session["" + i]) != null && Convert.ToString(Session["" + i]) != "")
                    manot[i] = "" + getKamutNum(Convert.ToString(Session["" + i])) + "X" + getNom(Convert.ToString(Session["" + i]));
            }

            for (int i = 0; i < ind; i++)
            {
                sum = getKamut2(manot[i]);
                sumAr = sumMana(lotos, tos, getName(manot[i]));
                if (sum != sumAr)
                {
                    if (sumAr > sum)
                        hod += "There are" + " " + Convert.ToString(sumAr - sum) + " " + "extra" + " " + getName(manot[i]) + ".";
                    else
                        hod += "There are" + " " + Convert.ToString(sum - sumAr) + " " + "missing" + " " + getName(manot[i]) + ".";
                }
                ;
            }
        }
        Label l = new Label();
        if (hod == "")
        {
            hod = "You did not miss a thing";
            l.ForeColor = Color.Green;
        }
        else
            l.ForeColor = Color.Red;
        
        l.Text = hod;
        this.div1.Controls.Add(l);


    }

    //מופעלת בלחיצה על כפתור שמירה. שומרת את כל נתוני החלוקה במסד הנתונים
    void submitOC(System.Object sender, EventArgs e)
    {


        int ind = Convert.ToInt32(Session["index1"]);
        ind++;
        int nop = Convert.ToInt32(Session["nop1"]);
        for (int i = 0; i < ind; i++)
        {
            string st = Convert.ToString(Session["" + i]);
            SqlConnection sc = new SqlConnection(db.connectionString);
            string mySqlStr = string.Format("INSERT INTO Manot VALUES ('{0}','{1}','{2}','{3}','{4}')", getNom(st), getPrice(st), getKh(st), getKs(st), getKamutUom(st));
            SqlCommand myCommandObj = new SqlCommand(mySqlStr, sc);
            myCommandObj.Connection.Open();
            myCommandObj.ExecuteNonQuery();
            myCommandObj.Connection.Close();
        }








        int iid = -1;
        Boolean yt = false;
        int idl = -1;
        int idt = -1;
        for (int i = 0; i < tbs.Length; i++)
        {
            string st = Convert.ToString(tbs[i].Text);
            yt = false;
            string lo = "";
            string to = "";
            lo = st.Substring(0, (st.IndexOf("+")));
            if (st.Length > st.IndexOf("+") + 1)
            {
                yt = true;
                to = st.Substring(st.IndexOf("+") + 1, (st.Length - st.IndexOf("+") - 1));
            }

            string myConnectionString = db.connectionString;
            string mySqlStr1 = "SELECT * FROM Manot WHERE Manot.NOM=@no AND Manot.PFO=@pf AND Manot.KH=@khh AND Manot.KS=@kss AND Manot.UOM=@uo ";
            SqlConnection mySqlConnection = new SqlConnection(myConnectionString);
            SqlCommand myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


            SqlParameter q1 = new SqlParameter();
            q1.ParameterName = "@no";
            q1.SqlDbType = SqlDbType.VarChar;
            q1.Value = getName(lo);
            myCommandObj1.Parameters.Add(q1);

            SqlParameter q2 = new SqlParameter();
            q2.ParameterName = "@pf";
            q2.SqlDbType = SqlDbType.Real;
            q2.Value = getPrice2(lo);
            myCommandObj1.Parameters.Add(q2);

            SqlParameter q3 = new SqlParameter();
            q3.ParameterName = "@khh";
            q3.SqlDbType = SqlDbType.Int;
            q3.Value = getKh2(lo);
            myCommandObj1.Parameters.Add(q3);

            SqlParameter q4 = new SqlParameter();
            q4.ParameterName = "@kss";
            q4.SqlDbType = SqlDbType.Int;
            q4.Value = getKs2(lo);
            myCommandObj1.Parameters.Add(q4);

            SqlParameter q5 = new SqlParameter();
            q5.ParameterName = "@uo";
            q5.SqlDbType = SqlDbType.VarChar;
            q5.Value = getKaum2(lo);
            myCommandObj1.Parameters.Add(q5);

            myCommandObj1.Connection.Open();
            SqlDataReader reader = myCommandObj1.ExecuteReader();


            while (reader.Read())
            {
                idl = Convert.ToInt32(reader["id"]);
            }
            reader.Close();
            myCommandObj1.Connection.Close();


            if (yt)
            {
                myConnectionString = db.connectionString;
                mySqlStr1 = "SELECT * FROM Manot WHERE Manot.NOM=@no AND Manot.PFO=@pf AND Manot.KH=@khh AND Manot.KS=@kss AND Manot.UOM=@uo ";
                mySqlConnection = new SqlConnection(myConnectionString);
                myCommandObj1 = new SqlCommand(mySqlStr1, mySqlConnection);


                q1 = new SqlParameter();
                q1.ParameterName = "@no";
                q1.SqlDbType = SqlDbType.VarChar;
                q1.Value = getName(to);
                myCommandObj1.Parameters.Add(q1);

                q2 = new SqlParameter();
                q2.ParameterName = "@pf";
                q2.SqlDbType = SqlDbType.Real;
                q2.Value = getPrice2(to);
                myCommandObj1.Parameters.Add(q2);

                q3 = new SqlParameter();
                q3.ParameterName = "@khh";
                q3.SqlDbType = SqlDbType.Int;
                q3.Value = getKh2(to);
                myCommandObj1.Parameters.Add(q3);

                q4 = new SqlParameter();
                q4.ParameterName = "@kss";
                q4.SqlDbType = SqlDbType.Int;
                q4.Value = getKs2(to);
                myCommandObj1.Parameters.Add(q4);

                q5 = new SqlParameter();
                q5.ParameterName = "@uo";
                q5.SqlDbType = SqlDbType.VarChar;
                q5.Value = getKaum2(to);
                myCommandObj1.Parameters.Add(q5);

                myCommandObj1.Connection.Open();
                reader = myCommandObj1.ExecuteReader();


                while (reader.Read())
                {
                    idt = Convert.ToInt32(reader["id"]);
                }
                reader.Close();
                myCommandObj1.Connection.Close();
            }

            string mySqlStr = "";
            double f = getKamut22(lo);
            string h = getKaum2(lo);
            SqlConnection sc = new SqlConnection(db.connectionString);
            if (yt)
                mySqlStr = string.Format("INSERT INTO Past VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", getKamut22(lo), getKaum2(lo), idl, getKamut22(to), getKaum2(to), idt, Convert.ToString(tbn[i].Text));
            else
                mySqlStr = string.Format("INSERT INTO Past VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", getKamut22(lo), getKaum2(lo), idl, null, null, null, Convert.ToString(tbn[i].Text));
            SqlCommand myCommandObj = new SqlCommand(mySqlStr, sc);
            myCommandObj.Connection.Open();
            myCommandObj.ExecuteNonQuery();
            myCommandObj.Connection.Close();
        }

        int ide = -1;
        int idb = -1;
        int ghf = 0;
        int nohins = -1;
        string myConnectionStringj = db.connectionString;
        string mySqlStr1j = "SELECT * FROM Past";
        SqlConnection mySqlConnectionj = new SqlConnection(myConnectionStringj);
        SqlCommand myCommandObj1j = new SqlCommand(mySqlStr1j, mySqlConnectionj);



        myCommandObj1j.Connection.Open();
        SqlDataReader readerj = myCommandObj1j.ExecuteReader();


        while (readerj.Read())
        {
            ide = Convert.ToInt32(readerj["id"]);
        }
        readerj.Close();
        myCommandObj1j.Connection.Close();

        for (int i = 0; i < tbs.Length; i++)
            if (tbs[i] != null)
                ghf++;
        ghf--;
        idb = ide - ghf;


        myConnectionStringj = db.connectionString;
        mySqlStr1j = "SELECT * FROM Events";
        mySqlConnectionj = new SqlConnection(myConnectionStringj);
        myCommandObj1j = new SqlCommand(mySqlStr1j, mySqlConnectionj);



        myCommandObj1j.Connection.Open();
        readerj = myCommandObj1j.ExecuteReader();


        while (readerj.Read())
        {
            nohins = Convert.ToInt32(readerj["NOH"]);
        }
        readerj.Close();
        myCommandObj1j.Connection.Close();
        nohins++;

        string mySqlStrj = "";
        SqlConnection scj = new SqlConnection(db.connectionString);
        int userid = 8;
        if (Session["userId1"] != "" && Session["userId1"] != null)
            userid = Convert.ToInt32(Session["userId1"]);
        string et = "";
        if (Convert.ToInt32(Session["maslul123"]) == 3)
            et = Convert.ToString(Session["dp1"]);
        else
            et = Convert.ToString(Session["eventType1"]);

        mySqlStrj = string.Format("INSERT INTO Events VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", nohins, nop, et, idb, ide, userid);
        SqlCommand myCommandObjj = new SqlCommand(mySqlStrj, scj);
        myCommandObjj.Connection.Open();
        myCommandObjj.ExecuteNonQuery();
        myCommandObjj.Connection.Close();

        if (Convert.ToString(Session["newMana1"]) != "")
        {
            div2.Visible = true;
        }
    }

    //במקרה שנוספו מנות חדשות והמשתמש בחר להוסיף להן אלרגנים. מופעלת בלחיצה על הקישור להוספת אלרגנים ומעבירה לדף הוספת האלרגנים
    public void lbOC(object sender, EventArgs e)
    {
        string[] newManot = Convert.ToString(Session["newMana1"]).Split(';');
        Response.Redirect("AddAllergens.aspx?msg=" + newManot[0]);
    }


}


