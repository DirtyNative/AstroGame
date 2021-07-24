import 'dart:async';

import 'package:astrogame_app/helpers/resource_helper.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/models/researches/levelable_research.dart';
import 'package:astrogame_app/models/researches/one_time_research.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/researches/research_study.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';
import 'package:astrogame_app/providers/image_provider.dart';
import 'package:astrogame_app/providers/research_study_provider.dart';
import 'package:astrogame_app/providers/stored_resource_provider.dart';
import 'package:astrogame_app/providers/studied_researches_provider.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:astrogame_app/views/researches/bags/research_detail_bag.dart';
import 'package:duration/duration.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class ResearchViewModel extends FutureViewModel {
  NavigationWrapper _navigationWrapper;

  StudiedResearchesProvider _studiedResearchesProvider;
  StoredResourceProvider _storedResourceProvider;
  ResearchImageProvider _researchImageProvider;
  ResearchStudyProvider _researchStudyProvider;

  EventService _eventService;
  ResourceHelper _resourceHelper;

  Timer _timer;

  ResearchViewModel(
    this._navigationWrapper,
    this._studiedResearchesProvider,
    this._researchImageProvider,
    this._storedResourceProvider,
    this._researchStudyProvider,
    this._eventService,
    this._resourceHelper,
    @factoryParam this._research,
  ) {
    /*_eventService.on<BuildingConstructionStartedEvent>().listen((event) async {
      await updateAsync();
    });

    _eventService.on<BuildingConstructionFinishedEvent>().listen((event) async {
      await updateAsync();
    }); */

    _timer = Timer.periodic(Duration(seconds: 1), (timer) {
      notifyListeners();
    });
  }

  Research _research;
  Research get research => _research;
  set research(Research val) {
    _research = val;
    notifyListeners();
  }

  FinishedTechnology _finishedTechnology;
  FinishedTechnology get finishedTechnology => _finishedTechnology;
  set finishedTechnology(FinishedTechnology val) {
    _finishedTechnology = val;
    notifyListeners();
  }

  ResearchStudy _researchStudy;
  ResearchStudy get researchStudy => _researchStudy;
  set researchStudy(ResearchStudy val) {
    _researchStudy = val;
    notifyListeners();
  }

  List<StoredResource> _storedResources;
  List<StoredResource> get storedResources => _storedResources;
  set storedResources(List<StoredResource> val) {
    _storedResources = val;
    notifyListeners();
  }

  ImageProvider _researchImage;
  ImageProvider get researchImage => _researchImage;
  set researchImage(ImageProvider val) {
    _researchImage = val;
    notifyListeners();
  }

  bool get isConstructable {
    // If there is a construction running on this StellarObject
    if (this.researchStudy != null) {
      return false;
    }

    var level = 0;

    if (finishedTechnology != null) {
      level = finishedTechnology.level;
    }

    // If this is a FixedBuilding and it's already built
    if (research is OneTimeResearch && finishedTechnology != null) {
      return false;
    }

    return _resourceHelper.hasStoredResourcesToStudy(
        storedResources, research, level);
  }

  String get studyText {
    // If this research is under construction
    if (researchStudy != null && researchStudy.technologyId == research.id) {
      var duration = researchStudy.endTime.difference(DateTime.now().toUtc());

      if (duration < Duration()) {
        duration = Duration();
      }

      return prettyDuration(duration, abbreviated: true, delimiter: ' : ');
    }

    if (research is LevelableResearch) {
      return (finishedTechnology == null)
          ? 'Study'
          : 'Upgrade ${finishedTechnology.level + 1}';
    } else if (research is OneTimeResearch) {
      return (finishedTechnology == null) ? 'Study' : 'Already studied';
    }

    throw Exception(
        'Research type ${research.runtimeType} is not implemented yet');
  }

  void showResearchDetails() {
    _navigationWrapper.navigateSubTo(
      RoutePaths.ResearchDetailsRoute,
      arguments: new ResearchDetailBag(research, finishedTechnology),
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
    finishedTechnology = await _fetchStudiedResearchAsync(research.id);
    researchStudy = await _fetchActiveResearchStudy();
    storedResources = await _fetchStoredResourcesAsync();
    researchImage = await _fetchImageAsync(research.assetName);
  }

  Future<FinishedTechnology> _fetchStudiedResearchAsync(Guid researchId) async {
    return await _studiedResearchesProvider.getByResearchAsync(researchId);
  }

  Future<ResearchStudy> _fetchActiveResearchStudy() async {
    return await _researchStudyProvider.get();
  }

  Future<List<StoredResource>> _fetchStoredResourcesAsync() async {
    return await _storedResourceProvider.getAsync();
  }

  Future<ImageProvider> _fetchImageAsync(String assetName) async {
    return await _researchImageProvider.get(assetName);
  }
}
