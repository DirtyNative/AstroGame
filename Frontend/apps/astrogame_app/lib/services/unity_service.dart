import 'package:astrogame_app/events/unity_container_loaded_event.dart';
import 'package:flutter_unity_widget/flutter_unity_widget.dart';
import 'package:injectable/injectable.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:astrogame_app/events/unity_message_received_event.dart';
import 'package:astrogame_app/events/scene_loaded_event.dart';

@singleton
class UnityService {
  EventService _eventService;

  // The controller which handles the input and output
  UnityWidgetController _unityController;

  UnityService(this._eventService);

  void setController(UnityWidgetController controller) {
    _unityController = controller;
    _eventService.fire(new UnityContainerLoadedEvent());
  }

  void onUnityMessage(message) {
    _eventService.fire(new UnityMessageReceivedEvent(message));
  }

  void onUnitySceneLoaded(SceneLoaded sceneInfo) {
    _eventService.fire(new SceneLoadedEvent(sceneInfo.name));
  }

  void postMessage(String gameObject, String methodName, String message) {
    _unityController.postMessage(gameObject, methodName, message);
  }

  void postJsonMessage(
      String gameObject, String methodName, Map<String, dynamic> message) {
    if (_unityController == null) {
      return;
    }

    _unityController.postJsonMessage(gameObject, methodName, message);
  }
}
