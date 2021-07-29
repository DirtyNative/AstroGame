import 'package:astrogame_app/models/buildings/dynamic_building_cost.dart';
import 'package:astrogame_app/models/buildings/fixed_building_cost.dart';
import 'package:astrogame_app/models/researches/dynamic_research_cost.dart';
import 'package:astrogame_app/models/researches/one_time_research_cost.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:astrogame_app/models/technologies/technology_cost.dart';
import 'package:injectable/injectable.dart';
import 'dart:math';
import 'package:collection/collection.dart';

@injectable
class ResourceHelper {
  bool hasStoredResourcesToBuild(
      List<StoredResource> resources, Technology technology, int level) {
    if (resources.length == 0) {
      return false;
    }

    if (technology.technologyCosts == null) {
      return true;
    }

    for (int index = 0; index < technology.technologyCosts!.length; index++) {
      var buildingCost = technology.technologyCosts![index];

      var amount = calculateConstructionAmount(buildingCost, level + 1);

      // Check if there are stored resources
      if (resources.any(
              (element) => element.resourceId == buildingCost.resourceId) ==
          false) {
        return false;
      }

      var storedResource = resources.firstWhereOrNull(
          (element) => element.resourceId == buildingCost.resourceId);

      if (storedResource == null) {
        return false;
      }

      if (storedResource.amount < amount) {
        return false;
      }
    }

    return true;
  }

  bool hasStoredResourcesToStudy(
      List<StoredResource> resources, Research research, int level) {
    if (resources.length == 0) {
      return false;
    }

    if (research.technologyCosts == null) {
      return true;
    }

    for (int index = 0; index < research.technologyCosts!.length; index++) {
      var researchCost = research.technologyCosts![index];

      var amount = calculateStudyAmount(researchCost, level + 1);

      // Check if there are stored resources
      if (resources.any(
              (element) => element.resourceId == researchCost.resourceId) ==
          false) {
        return false;
      }

      var storedResource = resources.firstWhereOrNull(
          (element) => element.resourceId == researchCost.resourceId);

      if (storedResource == null) {
        return false;
      }

      if (storedResource.amount < amount) {
        return false;
      }
    }

    return true;
  }

  double calculateConstructionAmount(TechnologyCost technologyCost, int level) {
    if (technologyCost is DynamicBuildingCost) {
      return technologyCost.baseValue *
          pow(technologyCost.multiplier, level - 1);
    } else if (technologyCost is FixedBuildingCost) {
      return technologyCost.amount;
    }

    throw Exception('${technologyCost.runtimeType} is not implemented yet');
  }

  double calculateStudyAmount(TechnologyCost technologyCost, int level) {
    if (technologyCost is DynamicResearchCost) {
      return technologyCost.baseValue *
          pow(technologyCost.multiplier, level - 1);
    } else if (technologyCost is OneTimeResearchCost) {
      return technologyCost.amount;
    }

    throw Exception('${technologyCost.runtimeType} is not implemented yet');
  }
}
