import 'dart:io';

import 'package:device_info/device_info.dart';
import 'package:flutter/foundation.dart';
import 'package:injectable/injectable.dart';

/// Provides information about the Device which is executing the app
//@preResolve
@singleton
class DeviceInfo {
  bool isPhysicalDevice;
  String model;
  String webViewUserAgent;

  DeviceInfo({
    this.isPhysicalDevice,
    this.model,
    this.webViewUserAgent,
  });

  @factoryMethod
  static Future<DeviceInfo> instance() async {
    var deviceInfo = new DeviceInfo();

    DeviceInfoPlugin plugin = DeviceInfoPlugin();

    if (Platform.isAndroid) {
      var androidInfo = await plugin.androidInfo;

      deviceInfo.isPhysicalDevice = androidInfo.isPhysicalDevice;
      deviceInfo.model = androidInfo.model;
    } else if (Platform.isIOS) {
      var iosDeviceInfo = await plugin.iosInfo;

      deviceInfo.isPhysicalDevice = iosDeviceInfo.isPhysicalDevice;
      deviceInfo.model = iosDeviceInfo.utsname.machine;
    } else if (Platform.isWindows) {
    } else if (Platform.isMacOS) {
    } else if (kIsWeb) {
    } else {}

    return deviceInfo;
  }
}
