namespace FloorChecker.iOS
{
    class iOSHardware
    {
        public string GetModel(string hardware)
        {
            // https://support.apple.com/kb/HT3939
            if (hardware.StartsWith("iPhone"))
            {
                if (hardware == "iPhone1,1")
                    return "iPhone";
                if (hardware == "iPhone1,2")
                    return "iPhone 3G";
                if (hardware == "iPhone2,1")
                    return "iPhone 3GS";
                if (hardware == "iPhone3,1" || hardware == "iPhone3,2")
                    return "iPhone 4 GSM";
                if (hardware == "iPhone3,3")
                    return "iPhone 4 CDMA";
                if (hardware == "iPhone4,1")
                    return "iPhone 4S";
                if (hardware == "iPhone5,1")
                    return "iPhone 5 GSM";
                if (hardware == "iPhone5,2")
                    return "iPhone 5 Global";
                if (hardware == "iPhone5,3")
                    return "iPhone 5C GSM";
                if (hardware == "iPhone5,4")
                    return "iPhone 5C Global";
                if (hardware == "iPhone6,1")
                    return "iPhone 5S GSM"; 
                if (hardware == "iPhone6,2")
                    return "iPhone 5S Global";
                if (hardware == "iPhone7,2")
                    return "iPhone 6";
                if (hardware == "iPhone7,1")
                    return "iPhone 6 Plus";
                if (hardware == "iPhone8,1")
                    return "iPhone 6S";
                if (hardware == "iPhone8,2")
                    return "iPhone 6S Plus";
                if (hardware == "iPhone8,4")
                    return "iPhone SE";
                if (hardware == "iPhone9,1" || hardware == "iPhone9,3")
                    return "iPhone 7";
                if (hardware == "iPhone9,2" || hardware == "iPhone9,4")
                    return "iPhone 7 Plus";
                if (hardware == "iPhone10,1" || hardware == "iPhone10,4")
                    return "iPhone 8";
                if (hardware == "iPhone10,2" || hardware == "iPhone10,5")
                    return "iPhone 8 Plus";
                if (hardware == "iPhone10,3" || hardware == "iPhone10,6")
                    return "iPhone X";
                if (hardware == "iPhone11,8")
                    return "iPhone XR";
                if (hardware == "iPhone11,4" || hardware == "iPhone11,6")
                    return "iPhone XS Max";
                if (hardware == "iPhone11,2")
                    return "iPhone XS";
            }

            if (hardware.StartsWith("iPod"))
            {
                if (hardware == "iPod1,1")
                    return "iPod touch";
                if (hardware == "iPod2,1")
                    return "iPod touch 2G";
                if (hardware == "iPod3,1")
                    return "iPod touch 3G";
                if (hardware == "iPod4,1")
                    return "iPod touch 4G";
                if (hardware == "iPod5,1")
                    return "iPod touch 5G";
                if (hardware == "iPod7,1")
                    return "iPod touch 6G";
                if (hardware == "iPod9,1")
                    return "iPod touch 7G";
            }

            if (hardware.StartsWith("iPad"))
            {
                if (hardware == "iPad1,1")
                    return "iPad";
                if (hardware == "iPad2,1")
                    return "iPad 2 Wi-Fi";
                if (hardware == "iPad2,2")
                    return "iPad 2 GSM";
                if (hardware == "iPad2,3")
                    return "iPad 2 CDMA";
                if (hardware == "iPad2,4")
                    return "iPad 2 Wi-Fi";
                if (hardware == "iPad3,1")
                    return "iPad 3 Wi-Fi";
                if (hardware == "iPad3,2")
                    return "iPad 3 Wi-Fi + Cellular (VZ)";
                if (hardware == "iPad3,3")
                    return "iPad 3 Wi-Fi + Cellular";
                if (hardware == "iPad3,4")
                    return "iPad 4 Wi-Fi";
                if (hardware == "iPad3,5")
                    return "iPad 4 Wi-Fi + Cellular";
                if (hardware == "iPad3,6")
                    return "iPad 4 Wi-Fi + Cellular (MM)";
                if (hardware == "iPad6,11")
                    return "iPad 5 Wi-Fi";
                if (hardware == "iPad6,12")
                    return "iPad 5 Wi-Fi + Cellular";
                if (hardware == "iPad7,5")
                    return "iPad 6 Wi-Fi";
                if (hardware == "iPad7,6")
                    return "iPad 6 Wi-Fi + Cellular";
                if (hardware == "iPad4,1")
                    return "iPad Air Wi-Fi";
                if (hardware == "iPad4,2")
                    return "iPad Air Wi-Fi + Cellular";
                if (hardware == "iPad4,3")
                    return "iPad Air Wi-Fi + Cellular (TD-LTE)";
                if (hardware == "iPad5,3")
                    return "iPad Air 2 Wi-Fi";
                if (hardware == "iPad5,4")
                    return "iPad Air 2 Wi-Fi + Cellular";
                if (hardware == "iPad11,3")
                    return "iPad Air 3 Wi-Fi";
                if (hardware == "iPad11,4")
                    return "iPad Air 3 Wi-Fi + Cellular";
                if (hardware == "iPad2,5")
                    return "iPad mini Wi-Fi";
                if (hardware == "iPad2,6")
                    return "iPad mini Wi-Fi + Cellular";
                if (hardware == "iPad2,7")
                    return "iPad mini Wi-Fi + Cellular (MM)";
                if (hardware == "iPad4,4")
                    return "iPad mini 2 Wi-Fi";
                if (hardware == "iPad4,5")
                    return "iPad mini 2 Wi-Fi + Cellular";
                if (hardware == "iPad4,6")
                    return "iPad mini 2 Wi-Fi + Cellular (TD-LTE)";
                if (hardware == "iPad4,7")
                    return "iPad mini 3 Wi-Fi";
                if (hardware == "iPad4,8")
                    return "iPad mini 3 Wi-Fi + Cellular";
                if (hardware == "iPad4,9")
                    return "iPad mini 3 Wi-Fi + Cellular (TD-LTE)";
                if (hardware == "iPad5,1")
                    return "iPad mini 4";
                if (hardware == "iPad5,2")
                    return "iPad mini 4 Wi-Fi + Cellular";
                if (hardware == "iPad11,1")
                    return "iPad mini 5 Wi-Fi";
                if (hardware == "iPad11,2")
                    return "iPad mini 5 Wi-Fi + Cellular";
                if (hardware == "iPad6,3")
                    return "iPad Pro (9.7-inch)";
                if (hardware == "iPad6,4")
                    return "iPad Pro (9.7-inch) Wi-Fi + Cellular";
                if (hardware == "iPad7,3")
                    return "iPad Pro (10.5-inch)";
                if (hardware == "iPad7,4")
                    return "iPad Pro (10.5-inch) Wi-Fi + Cellular";
                if (hardware == "iPad6,7")
                    return "iPad Pro 12.9-inch";
                if (hardware == "iPad6,8")
                    return "iPad Pro 12.9-inch Wi-Fi + Cellular";
                if (hardware == "iPad7,1")
                    return "iPad Pro 12.9-inch (2nd generation)";
                if (hardware == "iPad7,2")
                    return "iPad Pro 12.9-inch (2nd generation) Wi-Fi + Cellular";
                if (hardware == "iPad8,5" || hardware == "iPad8,6")
                    return "iPad Pro 12.9-inch (3rd generation)";
                if (hardware == "iPad8,7" || hardware == "iPad8,8")
                    return "iPad Pro 12.9-inch (3rd generation Wi-Fi + Cellular)";
                if (hardware == "iPad8,1" || hardware == "iPad8,2")
                    return "iPad Pro 11-inch";
                if (hardware == "iPad8,3" || hardware == "iPad8,4")
                    return "iPad Pro 11-inch Wi-Fi + Cellular";
            }

            if (hardware == "i386" || hardware == "x86_64")
                return "Simulator";

            return (hardware == "" ? "Unknown" : hardware);
        }
    }
}