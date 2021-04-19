import 'dart:async';

import 'package:astrogame_app/events/server_events/buildings/building_construction_finished_event.dart';
import 'package:astrogame_app/events/server_events/buildings/building_construction_started_event.dart';
import 'package:astrogame_app/executers/build_building_executer.dart';
import 'package:astrogame_app/helpers/resource_helper.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/building_construction.dart';
import 'package:astrogame_app/models/buildings/built_building.dart';
import 'package:astrogame_app/models/buildings/fixed_building.dart';
import 'package:astrogame_app/models/buildings/levelable_building.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:astrogame_app/providers/building_chain_provider.dart';
import 'package:astrogame_app/providers/building_image_provider.dart';
import 'package:astrogame_app/providers/constructed_buildings_provider.dart';
import 'package:astrogame_app/providers/selected_colonized_stellar_object_provider.dart';
import 'package:astrogame_app/providers/stored_resource_provider.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:astrogame_app/views/building_detail/bags/building_detail_bag.dart';
import 'package:duration/duration.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class BuildingViewModel extends FutureViewModel {
  NavigationWrapper _navigationWrapper;

  ConstructedBuildingsProvider _constructedBuildingsProvider;
  BuildingChainProvider _buildingChainProvider;
  SelectedColonizedStellarObjectProvider _selectedColonizedStellarObjectProvider;
  StoredResourceProvider _storedResourceProvider;
  BuildingImageProvider _buildingImageProvider;

  BuildBuildingExecuter _buildBuildingExecuter;

  EventService _eventService;
  ResourceHelper _resourceHelper;

  Timer _timer;

  BuildingViewModel(
    this._navigationWrapper,
    this._buildingChainProvider,
    this._constructedBuildingsProvider,
    this._selectedColonizedStellarObjectProvider,
    this._buildingImageProvider,
    this._storedResourceProvider,
    this._buildBuildingExecuter,
    this._eventService,
    this._resourceHelper,
    @factoryParam this._building,
  ) {
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

  Building _building;
  Building get building => _building;
  set building(Building val) {
    _building = val;
    notifyListeners();
  }

  BuiltBuilding _builtBuilding;
  BuiltBuilding get builtBuilding => _builtBuilding;
  set builtBuilding(BuiltBuilding val) {
    _builtBuilding = val;
    notifyListeners();
  }

  BuildingConstruction _buildingConstruction;
  BuildingConstruction get buildingConstruction => _buildingConstruction;
  set buildingConstruction(BuildingConstruction val) {
    _buildingConstruction = val;
    notifyListeners();
  }

  List<StoredResource> _storedResources;
  List<StoredResource> get storedResources => _storedResources;
  set storedResources(List<StoredResource> val) {
    _storedResources = val;
    notifyListeners();
  }

  ImageProvider _buildingImage;
  ImageProvider get buildingImage => _buildingImage;
  set buildingImage(ImageProvider val) {
    _buildingImage = val;
    notifyListeners();
  }

  bool get isConstructable {
    // If there is a construction running on this StellarObject
    if (this.buildingConstruction != null) {
      return false;
    }

    var level = 0;

    if (builtBuilding != null) {
      level = builtBuilding.level;
    }

    // If this is a FixedBuilding and it's already built
    if (building is FixedBuilding && builtBuilding != null) {
      return false;
    }

    return _resourceHelper.hasStoredResourcesToBuild(storedResources, building, level);
  }

  String get constructionText {
    // If this building is under construction
    if (buildingConstruction != null && buildingConstruction.buildingId == building.id) {
      var duration = _buildingConstruction.endTime.difference(DateTime.now().toUtc());

      if (duration < Duration()) {
        duration = Duration();
      }

      return prettyDuration(duration, abbreviated: true, delimiter: ' : ');
    }

    if (building is LevelableBuilding) {
      return (builtBuilding == null) ? 'Build' : 'Upgrade ${builtBuilding.level + 1}';
    } else if (building is FixedBuilding) {
      return (builtBuilding == null) ? 'Build' : 'Already built';
    }

    throw Exception('Building type ${building.runtimeType} is not implemented yet');
  }

  Future buildAsync() async {
    await _buildBuildingExecuter.buildBuildingAsync(building.id);

    await updateAsync();
  }

  void showBuildingDetails() {
    _navigationWrapper.navigateSubTo(
      RoutePaths.BuildingDetailsRoute,
      arguments: new BuildingDetailBag(building, builtBuilding),
    );
  }

  @override
  void dispose() {
    _timer.cancel();
    super.dispose();
  }

  @override
  Future futureToRun() => updateAsync();

  Future updateAsync() async {
    builtBuilding = await _fetchBuiltBuildingAsync(building.id);
    buildingConstruction = await _fetchActiveConstruction();
    storedResources = await _fetchStoredResourcesAsync();
    buildingImage = await _fetchImageAsync(building.id);
  }

  Future<BuiltBuilding> _fetchBuiltBuildingAsync(Guid buildingId) async {
    return await _constructedBuildingsProvider.getByBuildingAsync(buildingId);
  }

  Future<BuildingConstruction> _fetchActiveConstruction() async {
    return await _buildingChainProvider.getByStellarObject(_selectedColonizedStellarObjectProvider.getSelectedObject().stellarObjectId);
  }

  Future<List<StoredResource>> _fetchStoredResourcesAsync() async {
    return await _storedResourceProvider.getAsync();
  }

  Future<ImageProvider> _fetchImageAsync(Guid buildingId) async {
    return await _buildingImageProvider.get(buildingId);
  }
}
