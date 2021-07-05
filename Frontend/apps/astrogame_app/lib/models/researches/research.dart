import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/converters/research_converter.dart';
import 'package:astrogame_app/models/enums/research_type.dart';
import 'package:astrogame_app/models/technologies/technology.dart';

@GuidConverter()
abstract class Research extends Technology {
  String name;
  String description;
  int order;
  ResearchType researchType;
  String assetName;

  double buildingTimeMultiplier;
  double buildingCostMultiplier;
  double buildingProductionMultiplier;
  double buildingConsumptionMultiplier;

  double structuralIntegrityMultiplier;
  double shieldPowerMultiplier;
  double weaponPowerMultiplier;
  double cargoCapacityMultiplier;
  double stellarSpeedMultiplier;
  double interstellarSpeedMultiplier;
  double fuelConsumptionMultiplier;

  Research();

  factory Research.fromJson(Map<String, dynamic> json) =>
      ResearchConverter().fromJson(json);
}
