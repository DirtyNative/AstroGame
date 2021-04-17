import 'dart:async';
import 'package:astrogame_app/events/server_events/buildings/building_construction_finished_event.dart';
import 'package:astrogame_app/models/buildings/building_chain.dart';
import 'package:astrogame_app/providers/building_chain_provider.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class ConstructionsViewModel extends FutureViewModel {
  BuildingChainProvider _buildingChainProvider;

  EventService _eventService;

  Timer _timer;

  BuildingChain _buildingChain;
  BuildingChain get buildingChain => _buildingChain;
  set buildingChain(BuildingChain val) {
    _buildingChain = val;
    notifyListeners();
  }

  ConstructionsViewModel(
    this._buildingChainProvider,
    this._eventService,
  ) {
    _eventService.on<BuildingConstructionFinishedEvent>().listen((event) {
      notifyListeners();
    });

    _timer = Timer.periodic(Duration(seconds: 1), (timer) {
      notifyListeners();
    });
  }

  Future<BuildingChain> fetchBuildingChain() async {
    return await _buildingChainProvider.get();
  }

  @override
  void dispose() {
    _timer.cancel();
    super.dispose();
  }

  @override
  Future futureToRun() async {
    buildingChain = await fetchBuildingChain();
  }
}
