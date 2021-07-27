import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/converters/research_converter.dart';
import 'package:astrogame_app/models/enums/research_type.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class Research extends Technology {
  @JsonKey()
  late ResearchType researchType;

  @JsonKey()
  late double buildingTimeMultiplier;

  @JsonKey()
  late double buildingCostMultiplier;

  @JsonKey()
  late double buildingProductionMultiplier;

  @JsonKey()
  late double buildingConsumptionMultiplier;

  @JsonKey()
  late double structuralIntegrityMultiplier;

  @JsonKey()
  late double shieldPowerMultiplier;

  @JsonKey()
  late double weaponPowerMultiplier;

  @JsonKey()
  late double cargoCapacityMultiplier;

  @JsonKey()
  late double stellarSpeedMultiplier;

  @JsonKey()
  late double interstellarSpeedMultiplier;

  @JsonKey()
  late double fuelConsumptionMultiplier;

  Research();

  factory Research.fromJson(Map<String, dynamic> json) =>
      ResearchConverter().fromJson(json);
}
