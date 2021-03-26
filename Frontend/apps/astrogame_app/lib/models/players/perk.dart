import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'perk.g.dart';

@GuidConverter()
@JsonSerializable()
class Perk {
  Guid id;
  String title;
  String description;

  double buildingSpeedMultiplier;
  double engineersResearchSpeedMultiplier;
  double physicsResearchSpeedMultiplier;
  double biologicalResearchSpeedMultiplier;

  double buildingMaterialsProductionSpeed;
  double consumablesProductionSpeedMultiplier;
  double componentsProductionSpeedMultiplier;
  double alloysProductionSpeedMultiplier;
  double fuelsProductionSpeedMultiplier;

  double buildingMaterialsProductionValueMultiplier;
  double consumablesProductionValueMultiplier;
  double componentsProductionValueMultiplier;
  double alloysProductionValueMultiplier;
  double fuelsProductionValueMultiplier;

  Perk();

  factory Perk.fromJson(Map<String, dynamic> json) => _$PerkFromJson(json);
  Map<String, dynamic> toJson() => _$PerkToJson(this);
}
