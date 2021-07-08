import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/converters/research_converter.dart';
import 'package:astrogame_app/models/enums/research_type.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class Research extends Technology {
  @JsonKey()
  ResearchType researchType;

  @JsonKey()
  double buildingTimeMultiplier;

  @JsonKey()
  double buildingCostMultiplier;

  @JsonKey()
  double buildingProductionMultiplier;

  @JsonKey()
  double buildingConsumptionMultiplier;

  @JsonKey()
  double structuralIntegrityMultiplier;

  @JsonKey()
  double shieldPowerMultiplier;

  @JsonKey()
  double weaponPowerMultiplier;

  @JsonKey()
  double cargoCapacityMultiplier;

  @JsonKey()
  double stellarSpeedMultiplier;

  @JsonKey()
  double interstellarSpeedMultiplier;

  @JsonKey()
  double fuelConsumptionMultiplier;

  Research();

  factory Research.fromJson(Map<String, dynamic> json) =>
      ResearchConverter().fromJson(json);
}
