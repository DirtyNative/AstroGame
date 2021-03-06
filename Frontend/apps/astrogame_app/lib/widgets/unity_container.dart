import 'package:astrogame_app/services/unity_service.dart';
import 'package:flutter/material.dart';
import 'package:flutter_unity_widget/flutter_unity_widget.dart';
import 'package:injectable/injectable.dart';
import 'package:astrogame_app/configurations/device_info.dart';

@singleton
class UnityContainer extends StatelessWidget {
  final DeviceInfo _deviceInfo;
  final UnityService _unityService;

  UnityContainer(this._deviceInfo, this._unityService);

  @override
  Widget build(BuildContext context) {
    if (_deviceInfo.isPhysicalDevice) {
      return UnityWidget(
        onUnityCreated: onUnityCreated,
        onUnitySceneLoaded: (message) => onUnitySceneLoaded(message),
        onUnityMessage: onUnityMessage,
        fullscreen: false,
      );
    } else {
      return Container(
        child: Image.asset(
          "assets/planet_1.png",
          fit: BoxFit.cover,
        ),
        height: double.infinity,
      );
    }
  }

  void onUnityCreated(controller) {
    _unityService.setController(controller);
  }

  void onUnityMessage(message) {
    _unityService.onUnityMessage(message);
  }

  void onUnitySceneLoaded(SceneLoaded sceneInfo) {
    print('Scene loaded');
    _unityService.onUnitySceneLoaded(sceneInfo);
  }
}
