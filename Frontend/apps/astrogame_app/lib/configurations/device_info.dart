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

  DeviceInfo(
    this.isPhysicalDevice,
    this.model,
    this.webViewUserAgent,
  );

  @factoryMethod
  static Future<DeviceInfo> instance() async {
    bool isPhysicalDevice = false;
    String model = '';
    String webViewUserAgent = '';

    DeviceInfoPlugin plugin = DeviceInfoPlugin();

    if (Platform.isAndroid) {
      var androidInfo = await plugin.androidInfo;

      isPhysicalDevice = androidInfo.isPhysicalDevice;
      model = androidInfo.model;
    } else if (Platform.isIOS) {
      var iosDeviceInfo = await plugin.iosInfo;

      isPhysicalDevice = iosDeviceInfo.isPhysicalDevice;
      model = iosDeviceInfo.utsname.machine;
    } else if (Platform.isWindows) {
    } else if (Platform.isMacOS) {
    } else if (kIsWeb) {
    } else {}

    return new DeviceInfo(isPhysicalDevice, model, webViewUserAgent);
  }
}
