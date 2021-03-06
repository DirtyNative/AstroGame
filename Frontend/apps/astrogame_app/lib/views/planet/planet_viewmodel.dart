import 'package:astrogame_app/events/scene_loaded_event.dart';
import 'package:astrogame_app/models/instantiation/planet_instantiation.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:astrogame_app/services/unity_service.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';
import 'package:astrogame_app/events/unity_container_loaded_event.dart';

@injectable
class PlanetViewModel extends BaseViewModel {
  EventService _eventService;
  UnityService _unityService;

  PlanetViewModel(this._eventService, this._unityService) {
    /*_eventService.on<UnityContainerLoadedEvent>().listen((event) {
      instantiate();
    });*/

    _eventService.on<SceneLoadedEvent>().listen((event) {
      instantiate();
    });
  }

  void instantiate() {
    var json = new PlanetInstantiation('Planet_Volcano_1', '', '', '').toJson();

    _unityService.postJsonMessage('Instantiator', 'Instantiate', json);
  }
}
