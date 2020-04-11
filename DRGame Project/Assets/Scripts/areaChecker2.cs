using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaChecker2 : MonoBehaviour
{
    area[] areas;
    location[] locations;
    border[] borders;
    location currentLocation;

    border northBorder, southBorder;

    // Start is called before the first frame update
    void Start()
    {
        makeAreas();
        makeLocations();
        makeBorders();
        northBorder = new border(new location(90, 0), new location(90, 0));
        southBorder = new border(new location(-90, 0), new location(90, 0));
    }

    // Update is called once per frame
    void Update()
    {
        double lngStart, latStart, lngEnd, latEnd, latitudeOnBorder, difference;

        //現在位置をとってくる
        //test lat-long 35.625665,139.884419
        currentLocation = new location(35.625665, 139.884419);

        for(int i=0;i<borders.Length;i++)
        {
            // get location data of start and end point of checked border
            lngStart = borders[i].getstartPoint().getlongitude(); 
            latStart = borders[i].getstartPoint().getlatiude();
            lngEnd = borders[i].getendPoint().getlongitude();
            latEnd = borders[i].getendPoint().getlatitude();

            // check
            if (lngStart < currentLocation.getlongitude()
                && currentLocation.getlongitude() < lngEnd)
            {
                // calculate target latitude on checked border
                latitudeOnBorder = (latEnd - latStart)(lngStart - lngStart) / (lngEnd - lngStart) + latEnd;
                   
                // calculate difference of latitude between currentLocation and checked border
                difference = latitudeOnBorder - currentLocation.getlatitude();
                
                // compare dif with north border
                if (difference > 0 
                    && difference < (northBorder.getlatitude() - currentLocation.getlatitude()))
                { northBorder = borders[i]; }
                // compare dif with south border
                else if (difference < 0
                    && difference > (southBorder.getlatitude() - currentLocation.getlatitude()))
                { southBorder = borders[i]; }
            }
        }

        // judge area by south and north norder


        //割り出したエリアをテキストボックスに表示させる

    }
    void makeAreas()
    {
        areas = new area[9];
        areas[0] = new area(0, "入口");
        areas[1] = new area(1, "メディテレーニアンハーバー");
        areas[2] = new area(2, "アメリカンウォーターフロント");
        areas[3] = new area(3, "ミステリアスアイランド");
        areas[4] = new area(4, "ポートディスカバリー");
        areas[5] = new area(5, "マーメイドラグーン");
        areas[6] = new area(6, "ロストリバーデルタ");
        areas[7] = new area(7, "アラビアンコースト");
        areas[8] = new area(8, "園外");
    }
    void makeLocations() 
    {
        locations = new location[65];
        locations[0] = new location(35.62697, 139.879817);
        locations[1] = new location(35.62812, 139.880291);
        locations[2] = new location(35.62927, 139.880641);
        locations[3] = new location(35.6244, 139.880921);
        locations[4] = new location(35.62542, 139.88167);
        locations[5] = new location(35.62788, 139.881681);
        locations[6] = new location(35.62514, 139.881833);
        locations[7] = new location(35.62766, 139.881886);
        locations[8] = new location(35.62769, 139.882021);
        locations[9] = new location(35.62493, 139.882025);
        locations[10] = new location(35.6272, 139.882052);
        locations[11] = new location(35.62701, 139.882093);
        locations[12] = new location(35.62718, 139.88215);
        locations[13] = new location(35.62737, 139.882237);
        locations[14] = new location(35.62689, 139.882262);
        locations[15] = new location(35.62776, 139.882311);
        locations[16] = new location(35.62405, 139.882317);
        locations[17] = new location(35.62611, 139.88249);
        locations[18] = new location(35.62559, 139.882904);
        locations[19] = new location(35.62598, 139.882988);
        locations[20] = new location(35.62752, 139.88331);
        locations[21] = new location(35.62384, 139.883341);
        locations[22] = new location(35.62592, 139.883426);
        locations[23] = new location(35.62774, 139.88347);
        locations[24] = new location(35.6279, 139.883593);
        locations[25] = new location(35.62875, 139.883687);
        locations[26] = new location(35.62517, 139.883898);
        locations[27] = new location(35.62413, 139.883964);
        locations[28] = new location(35.62729, 139.884041);
        locations[29] = new location(35.6254, 139.884078);
        locations[30] = new location(35.62498, 139.884203);
        locations[31] = new location(35.62403, 139.884232);
        locations[32] = new location(35.6278, 139.884258);
        locations[33] = new location(35.62477, 139.884324);
        locations[34] = new location(35.62425, 139.884388);
        locations[35] = new location(35.62719, 139.884956);
        locations[36] = new location(35.62516, 139.884978);
        locations[37] = new location(35.62764, 139.884991);
        locations[38] = new location(35.62782, 139.88527);
        locations[39] = new location(35.62717, 139.885331);
        locations[40] = new location(35.6267, 139.885352);
        locations[41] = new location(35.62613, 139.885492);
        locations[42] = new location(35.6281, 139.885533);
        locations[43] = new location(35.62522, 139.885583);
        locations[44] = new location(35.6251, 139.885615);
        locations[45] = new location(35.62603, 139.885797);
        locations[46] = new location(35.62777, 139.885823);
        locations[47] = new location(35.62757, 139.885836);
        locations[48] = new location(35.62529, 139.885838);
        locations[49] = new location(35.62757, 139.886115);
        locations[50] = new location(35.62767, 139.886228);
        locations[51] = new location(35.62729, 139.886747);
        locations[52] = new location(35.62534, 139.886896);
        locations[53] = new location(35.62553, 139.887059);
        locations[54] = new location(35.62713, 139.887217);
        locations[55] = new location(35.62559, 139.887265);
        locations[56] = new location(35.62542, 139.887532);
        locations[57] = new location(35.62289, 139.88778);
        locations[58] = new location(35.62733, 139.88794);
        locations[59] = new location(35.62626, 139.888081);
        locations[60] = new location(35.62579, 139.888172);
        locations[61] = new location(35.62601, 139.888191);
        locations[62] = new location(35.62631, 139.888314);
        locations[63] = new location(35.6256, 139.888576);
        locations[64] = new location(35.62467, 139.889863);
    }
    void makeBorders()
    {
        borders = new border[67];
        borders[0] = new border(locations[0], locations[1], areas[8], areas[6]);
        borders[1] = new border(locations[0], locations[3], areas[6], areas[8]);
        borders[2] = new border(locations[1], locations[2], areas[7], areas[8]);
        borders[3] = new border(locations[1], locations[5], areas[7], areas[6]);
        borders[4] = new border(locations[2], locations[25], areas[8], areas[7]);
        borders[5] = new border(locations[3], locations[16], areas[6], areas[8]);
        borders[6] = new border(locations[4], locations[6], areas[4], areas[6]);
        borders[7] = new border(locations[4], locations[18], areas[6], areas[4]);
        borders[8] = new border(locations[5], locations[7], areas[7], areas[6]);
        borders[9] = new border(locations[6], locations[9], areas[4], areas[6]);
        borders[10] = new border(locations[7], locations[8], areas[7], areas[6]);
        borders[11] = new border(locations[8], locations[13], areas[5], areas[6]);
        borders[12] = new border(locations[8], locations[15], areas[7], areas[5]);
        borders[13] = new border(locations[9], locations[16], areas[5], areas[6]);
        borders[14] = new border(locations[10], locations[12], areas[5], areas[6]);
        borders[15] = new border(locations[10], locations[13], areas[6], areas[5]);
        borders[16] = new border(locations[11], locations[12], areas[6], areas[5]);
        borders[17] = new border(locations[11], locations[14], areas[5], areas[6]);
        borders[18] = new border(locations[14], locations[17], areas[5], areas[6]);
        borders[19] = new border(locations[15], locations[20], areas[7], areas[5]);
        borders[20] = new border(locations[16], locations[21], areas[4], areas[8]);
        borders[21] = new border(locations[17], locations[19], areas[5], areas[6]);
        borders[22] = new border(locations[20], locations[23], areas[7], areas[5]);
        borders[23] = new border(locations[21], locations[27], areas[4], areas[2]);
        borders[24] = new border(locations[21], locations[57], areas[2], areas[8]);
        borders[25] = new border(locations[22], locations[28], areas[5], areas[3]);
        borders[26] = new border(locations[22], locations[29], areas[3], areas[4]);
        borders[27] = new border(locations[23], locations[24], areas[7], areas[5]);
        borders[28] = new border(locations[24], locations[25], areas[7], areas[8]);
        borders[29] = new border(locations[24], locations[32], areas[8], areas[5]);
        borders[30] = new border(locations[26], locations[29], areas[4], areas[2]);
        borders[31] = new border(locations[27], locations[31], areas[4], areas[2]);
        borders[32] = new border(locations[28], locations[32], areas[5], areas[8]);
        borders[33] = new border(locations[28], locations[35], areas[8], areas[3]);
        borders[34] = new border(locations[29], locations[36], areas[3], areas[2]);
        borders[35] = new border(locations[30], locations[33], areas[2], areas[4]);
        borders[36] = new border(locations[31], locations[34], areas[4], areas[2]);
        borders[37] = new border(locations[33], locations[34], areas[2], areas[4]);
        borders[38] = new border(locations[35], locations[39], areas[8], areas[1]);
        borders[39] = new border(locations[35], locations[40], areas[1], areas[3]);
        borders[40] = new border(locations[37], locations[38], areas[8], areas[1]);
        borders[41] = new border(locations[37], locations[39], areas[1], areas[8]);
        borders[42] = new border(locations[38], locations[42], areas[8], areas[1]);
        borders[43] = new border(locations[40], locations[41], areas[1], areas[3]);
        borders[44] = new border(locations[41], locations[45], areas[1], areas[3]);
        borders[45] = new border(locations[42], locations[46], areas[8], areas[1]);
        borders[46] = new border(locations[43], locations[44], areas[1], areas[3]);
        borders[47] = new border(locations[43], locations[48], areas[3], areas[1]);
        borders[48] = new border(locations[44], locations[52], areas[1], areas[2]);
        borders[49] = new border(locations[45], locations[48], areas[2], areas[3]);
        borders[50] = new border(locations[46], locations[47], areas[8], areas[1]);
        borders[51] = new border(locations[47], locations[49], areas[8], areas[1]);
        borders[52] = new border(locations[49], locations[50], areas[8], areas[1]);
        borders[53] = new border(locations[50], locations[51], areas[8], areas[1]);
        borders[54] = new border(locations[51], locations[54], areas[8], areas[1]);
        borders[55] = new border(locations[52], locations[53], areas[1], areas[2]);
        borders[56] = new border(locations[53], locations[55], areas[1], areas[2]);
        borders[57] = new border(locations[54], locations[58], areas[8], areas[1]);
        borders[58] = new border(locations[55], locations[56], areas[1], areas[2]);
        borders[59] = new border(locations[56], locations[63], areas[1], areas[2]);
        borders[60] = new border(locations[57], locations[64], areas[1], areas[8]);
        borders[61] = new border(locations[58], locations[62], areas[8], areas[1]);
        borders[62] = new border(locations[59], locations[61], areas[8], areas[1]);
        borders[63] = new border(locations[59], locations[62], areas[1], areas[8]);
        borders[64] = new border(locations[60], locations[61], areas[1], areas[8]);
        borders[65] = new border(locations[60], locations[63], areas[8], areas[1]);
        borders[66] = new border(locations[63], locations[64], areas[8], areas[2]);
    }

}
