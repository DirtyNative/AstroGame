import 'dart:async';

import 'package:astrogame_app/events/server_events/buildings/building_construction_finished_event.dart';
import 'package:astrogame_app/events/server_events/buildings/building_construction_started_event.dart';
import 'package:astrogame_app/executers/build_building_executer.dart';
import 'package:astrogame_app/helpers/resource_helper.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/building_construction.dart';
import 'package:astrogame_app/models/buildings/fixed_building.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';
import 'package:astrogame_app/models/technologies/levelable_technology.dart';
import 'package:astrogame_app/models/technologies/one_time_technology.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:astrogame_app/models/technologies/technology_upgrade.dart';
import 'package:astrogame_app/providers/building_chain_provider.dart';
import 'package:astrogame_app/providers/constructed_buildings_provider.dart';
import 'package:astrogame_app/providers/fulfilled_conditions_provider.dart';
import 'package:astrogame_app/providers/image_provider.dart';
import 'package:astrogame_app/providers/stored_resource_provider.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:astrogame_app/views/building_detail/bags/building_detail_bag.dart';
import 'package:astrogame_app/views/researches/bags/research_detail_bag.dart';
import 'package:duration/duration.dart';
import 'package:flutter/widgets.dart';

import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class TechnologyCardViewModel extends FutureViewModel {
  NavigationWrapper _navigationWrapper;

  ConstructedBuildingsProvider _constructedBuildingsProvider;
  BuildingChainProvider _buildingChainProvider;

  StoredResourceProvider _storedResourceProvider;
  AssetImageProvider _assetImageProvider;
  FulfilledConditionsProvider _fulfilledConditionsProvider;

  BuildBuildingExecuter _buildBuildingExecuter;

  EventService _eventService;
  ResourceHelper _resourceHelper;

  late Timer _timer;

  TechnologyCardViewModel(
    this._navigationWrapper,
    this._buildingChainProvider,
    this._constructedBuildingsProvider,
    this._assetImageProvider,
    this._storedResourceProvider,
    this._fulfilledConditionsProvider,
    this._buildBuildingExecuter,
    this._eventService,
    this._resourceHelper,
    @factoryParam this.technology,
  ) : assert(technology != null) {
    _eventService.on<BuildingConstructionStartedEvent>().listen((event) async {
      await updateAsync();
    });

    _eventService.on<BuildingConstructionFinishedEvent>().listen((event) async {
      await updateAsync();
    });

    _timer = Timer.periodic(Duration(seconds: 1), (timer) {
      notifyListeners();
    });
  }

  Technology? technology;

  FinishedTechnology? _finishedTechnology;
  FinishedTechnology? get finishedTechnology => _finishedTechnology;
  set finishedTechnology(FinishedTechnology? val) {
    _finishedTechnology = val;
    notifyListeners();
  }

  TechnologyUpgrade? _technologyUpgrade;
  TechnologyUpgrade? get technologyUpgrade => _technologyUpgrade;
  set technologyUpgrade(TechnologyUpgrade? val) {
    _technologyUpgrade = val;
    notifyListeners();
  }

  late List<StoredResource> _storedResources;
  List<StoredResource> get storedResources => _storedResources;
  set storedResources(List<StoredResource> val) {
    _storedResources = val;
    notifyListeners();
  }

  late ImageProvider _buildingImage;
  ImageProvider get buildingImage => _buildingImage;
  set buildingImage(ImageProvider val) {
    _buildingImage = val;
    notifyListeners();
  }

  late bool _hasFulfilledConditions;
  bool get hasFulfilledConditions => _hasFulfilledConditions;
  set hasFulfilledConditions(bool val) {
    _hasFulfilledConditions = val;
    notifyListeners();
  }

  bool get isConstructable {
    // If there is a construction running on this StellarObject
    if (this.technologyUpgrade != null) {
      return false;
    }

    // If the conditions are not fulfilled
    if (hasFulfilledConditions == false) {
      return false;
    }

    var level = 0;

    if (finishedTechnology != null) {
      level = finishedTechnology!.level;
    }

    // If this is a FixedBuilding and it's already built
    if (technology is FixedBuilding && finishedTechnology != null) {
      return false;
    }

    return _resourceHelper.hasStoredResourcesToBuild(
        storedResources, technology!, level);
  }

  String get constructionText {
    // If this building is under construction
    if (technologyUpgrade != null &&
        technologyUpgrade!.technologyId == technology!.id) {
      var duration =
          _technologyUpgrade!.endTime.difference(DateTime.now().toUtc());

      if (duration < Duration()) {
        duration = Duration();
      }

      return prettyDuration(duration, abbreviated: true, delimiter: ' : ');
    }

    if (technology is LevelableTechnology) {
      return (finishedTechnology == null)
          ? 'Build'
          : 'Upgrade ${finishedTechnology!.level + 1}';
    } else if (technology is OneTimeTechnology) {
      return (finishedTechnology == null) ? 'Build' : 'Already built';
    }

    throw Exception(
        'Technology type ${technology.runtimeType} is not implemented yet');
  }

  Future buildAsync() async {
    await _buildBuildingExecuter.buildBuildingAsync(technology!.id);

    await updateAsync();
  }

  void showBuildingDetails() {
    if (technology is Building) {
      _navigationWrapper.navigateSubTo(
        RoutePaths.BuildingDetailsRoute,
        arguments: new BuildingDetailBag(
          technology as Building,
          finishedTechnology,
        ),
      );
    } else if (technology is Research) {
      _navigationWrapper.navigateSubTo(
        RoutePaths.ResearchDetailsRoute,
        arguments: new ResearchDetailBag(
          technology as Research,
          finishedTechnology,
        ),
      );
    } else {
      throw Exception(
          'Technology ${technology.runtimeType} is not implemented yet');
    }
  }

  @override
  void dispose() {
    _timer.cancel();
    super.dispose();
  }

  @override
  Future futureToRun() => updateAsync();

  Future updateAsync() async {
    finishedTechnology = await _fetchBuiltBuildingAsync(technology!.id);
    technologyUpgrade = await _fetchActiveConstruction();
    storedResources = await _fetchStoredResourcesAsync();
    buildingImage = await _fetchImageAsync(technology!.assetName);
    hasFulfilledConditions = await _fetchHasFulfilledConditions(technology!.id);
  }

  Future<FinishedTechnology?> _fetchBuiltBuildingAsync(Guid buildingId) async {
    return await _constructedBuildingsProvider.getByBuildingAsync(buildingId);
  }

  Future<BuildingConstruction?> _fetchActiveConstruction() async {
    return await _buildingChainProvider.getOnCurrentStellarObject();
  }

  Future<List<StoredResource>> _fetchStoredResourcesAsync() async {
    return await _storedResourceProvider.getAsync();
  }

  Future<ImageProvider> _fetchImageAsync(String assetName) async {
    if (technology is Building) {
      return await _assetImageProvider.get(assetName, ImageScope.building);
    } else if (technology is Research) {
      return await _assetImageProvider.get(assetName, ImageScope.research);
    } else {
      throw Exception(
          'Technology ${technology.runtimeType} is not implemented yet');
    }
  }

  Future<bool> _fetchHasFulfilledConditions(Guid technologyId) async {
    return await _fulfilledConditionsProvider.get(technologyId);
  }
}
