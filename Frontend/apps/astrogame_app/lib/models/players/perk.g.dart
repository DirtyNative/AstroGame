// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'perk.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Perk _$PerkFromJson(Map<String, dynamic> json) {
  return Perk()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..title = json['title'] as String
    ..description = json['description'] as String
    ..buildingSpeedMultiplier =
        (json['buildingSpeedMultiplier'] as num)?.toDouble()
    ..engineersResearchSpeedMultiplier =
        (json['engineersResearchSpeedMultiplier'] as num)?.toDouble()
    ..physicsResearchSpeedMultiplier =
        (json['physicsResearchSpeedMultiplier'] as num)?.toDouble()
    ..biologicalResearchSpeedMultiplier =
        (json['biologicalResearchSpeedMultiplier'] as num)?.toDouble()
    ..buildingMaterialsProductionSpeed =
        (json['buildingMaterialsProductionSpeed'] as num)?.toDouble()
    ..consumablesProductionSpeedMultiplier =
        (json['consumablesProductionSpeedMultiplier'] as num)?.toDouble()
    ..componentsProductionSpeedMultiplier =
        (json['componentsProductionSpeedMultiplier'] as num)?.toDouble()
    ..alloysProductionSpeedMultiplier =
        (json['alloysProductionSpeedMultiplier'] as num)?.toDouble()
    ..fuelsProductionSpeedMultiplier =
        (json['fuelsProductionSpeedMultiplier'] as num)?.toDouble()
    ..buildingMaterialsProductionValueMultiplier =
        (json['buildingMaterialsProductionValueMultiplier'] as num)?.toDouble()
    ..consumablesProductionValueMultiplier =
        (json['consumablesProductionValueMultiplier'] as num)?.toDouble()
    ..componentsProductionValueMultiplier =
        (json['componentsProductionValueMultiplier'] as num)?.toDouble()
    ..alloysProductionValueMultiplier =
        (json['alloysProductionValueMultiplier'] as num)?.toDouble()
    ..fuelsProductionValueMultiplier =
        (json['fuelsProductionValueMultiplier'] as num)?.toDouble();
}

Map<String, dynamic> _$PerkToJson(Perk instance) => <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'title': instance.title,
      'description': instance.description,
      'buildingSpeedMultiplier': instance.buildingSpeedMultiplier,
      'engineersResearchSpeedMultiplier':
          instance.engineersResearchSpeedMultiplier,
      'physicsResearchSpeedMultiplier': instance.physicsResearchSpeedMultiplier,
      'biologicalResearchSpeedMultiplier':
          instance.biologicalResearchSpeedMultiplier,
      'buildingMaterialsProductionSpeed':
          instance.buildingMaterialsProductionSpeed,
      'consumablesProductionSpeedMultiplier':
          instance.consumablesProductionSpeedMultiplier,
      'componentsProductionSpeedMultiplier':
          instance.componentsProductionSpeedMultiplier,
      'alloysProductionSpeedMultiplier':
          instance.alloysProductionSpeedMultiplier,
      'fuelsProductionSpeedMultiplier': instance.fuelsProductionSpeedMultiplier,
      'buildingMaterialsProductionValueMultiplier':
          instance.buildingMaterialsProductionValueMultiplier,
      'consumablesProductionValueMultiplier':
          instance.consumablesProductionValueMultiplier,
      'componentsProductionValueMultiplier':
          instance.componentsProductionValueMultiplier,
      'alloysProductionValueMultiplier':
          instance.alloysProductionValueMultiplier,
      'fuelsProductionValueMultiplier': instance.fuelsProductionValueMultiplier,
    };
