import 'dart:async';
import 'package:astrogame_app/events/server_events/buildings/technology_upgrade_finished_event.dart';
import 'package:astrogame_app/events/server_events/buildings/technology_upgrade_started_event.dart';
import 'package:astrogame_app/models/technologies/technology_upgrade.dart';
import 'package:astrogame_app/providers/technology_upgrades_provider.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class ConstructionsViewModel extends FutureViewModel {
  TechnologyUpgradesProvider _technologyUpgradesProvider;

  EventService _eventService;

  late Timer _timer;

  late List<TechnologyUpgrade> _technologyUpgrades = [];
  List<TechnologyUpgrade> get technologyUpgrades => _technologyUpgrades;
  set technologyUpgrades(List<TechnologyUpgrade> val) {
    _technologyUpgrades = val;
    notifyListeners();
  }

  ConstructionsViewModel(
    this._technologyUpgradesProvider,
    this._eventService,
  ) {
    _eventService.on<TechnologyUpgradeStartedEvent>().listen((event) async {
      await futureToRun();
    });
    _eventService.on<TechnologyUpgradeFinishedEvent>().listen((event) async {
      await futureToRun();
    });

    _timer = Timer.periodic(Duration(seconds: 1), (timer) {
      notifyListeners();
    });
  }

  @override
  Future futureToRun() async {
    technologyUpgrades = await fetchTechnologyUpgradesAsync();
  }

  Future<List<TechnologyUpgrade>> fetchTechnologyUpgradesAsync() async {
    return await _technologyUpgradesProvider.get();
  }

  @override
  void dispose() {
    _timer.cancel();
    super.dispose();
  }
}
