import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';

import 'package:json_annotation/json_annotation.dart';

part 'perk.g.dart';

@GuidConverter()
@JsonSerializable()
class Perk {
  late Guid id;
  late String title;
  late String description;

  late double buildingSpeedMultiplier;
  late double engineersResearchSpeedMultiplier;
  late double physicsResearchSpeedMultiplier;
  late double biologicalResearchSpeedMultiplier;

  late double buildingMaterialsProductionSpeed;
  late double consumablesProductionSpeedMultiplier;
  late double componentsProductionSpeedMultiplier;
  late double alloysProductionSpeedMultiplier;
  late double fuelsProductionSpeedMultiplier;

  late double buildingMaterialsProductionValueMultiplier;
  late double consumablesProductionValueMultiplier;
  late double componentsProductionValueMultiplier;
  late double alloysProductionValueMultiplier;
  late double fuelsProductionValueMultiplier;

  Perk();

  factory Perk.fromJson(Map<String, dynamic> json) => _$PerkFromJson(json);
  Map<String, dynamic> toJson() => _$PerkToJson(this);
}
