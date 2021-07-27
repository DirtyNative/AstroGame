// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'levelable_research.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

LevelableResearch _$LevelableResearchFromJson(Map<String, dynamic> json) {
  return LevelableResearch()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..name = json['name'] as String
    ..description = json['description'] as String
    ..assetName = json['assetName'] as String
    ..order = json['order'] as int
    ..neededConditions = (json['neededConditions'] as List<dynamic>?)
        ?.map((e) => Condition.fromJson(e as Map<String, dynamic>))
        .toList()
    ..conditionFor = (json['conditionFor'] as List<dynamic>?)
        ?.map((e) => Condition.fromJson(e as Map<String, dynamic>))
        .toList()
    ..technologyCosts = (json['technologyCosts'] as List<dynamic>?)
        ?.map((e) => TechnologyCost.fromJson(e as Map<String, dynamic>))
        .toList()
    ..researchType = _$enumDecode(_$ResearchTypeEnumMap, json['researchType'])
    ..buildingTimeMultiplier =
        (json['buildingTimeMultiplier'] as num).toDouble()
    ..buildingCostMultiplier =
        (json['buildingCostMultiplier'] as num).toDouble()
    ..buildingProductionMultiplier =
        (json['buildingProductionMultiplier'] as num).toDouble()
    ..buildingConsumptionMultiplier =
        (json['buildingConsumptionMultiplier'] as num).toDouble()
    ..structuralIntegrityMultiplier =
        (json['structuralIntegrityMultiplier'] as num).toDouble()
    ..shieldPowerMultiplier = (json['shieldPowerMultiplier'] as num).toDouble()
    ..weaponPowerMultiplier = (json['weaponPowerMultiplier'] as num).toDouble()
    ..cargoCapacityMultiplier =
        (json['cargoCapacityMultiplier'] as num).toDouble()
    ..stellarSpeedMultiplier =
        (json['stellarSpeedMultiplier'] as num).toDouble()
    ..interstellarSpeedMultiplier =
        (json['interstellarSpeedMultiplier'] as num).toDouble()
    ..fuelConsumptionMultiplier =
        (json['fuelConsumptionMultiplier'] as num).toDouble();
}

Map<String, dynamic> _$LevelableResearchToJson(LevelableResearch instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'name': instance.name,
      'description': instance.description,
      'assetName': instance.assetName,
      'order': instance.order,
      'neededConditions': instance.neededConditions,
      'conditionFor': instance.conditionFor,
      'technologyCosts': instance.technologyCosts,
      'researchType': _$ResearchTypeEnumMap[instance.researchType],
      'buildingTimeMultiplier': instance.buildingTimeMultiplier,
      'buildingCostMultiplier': instance.buildingCostMultiplier,
      'buildingProductionMultiplier': instance.buildingProductionMultiplier,
      'buildingConsumptionMultiplier': instance.buildingConsumptionMultiplier,
      'structuralIntegrityMultiplier': instance.structuralIntegrityMultiplier,
      'shieldPowerMultiplier': instance.shieldPowerMultiplier,
      'weaponPowerMultiplier': instance.weaponPowerMultiplier,
      'cargoCapacityMultiplier': instance.cargoCapacityMultiplier,
      'stellarSpeedMultiplier': instance.stellarSpeedMultiplier,
      'interstellarSpeedMultiplier': instance.interstellarSpeedMultiplier,
      'fuelConsumptionMultiplier': instance.fuelConsumptionMultiplier,
    };

K _$enumDecode<K, V>(
  Map<K, V> enumValues,
  Object? source, {
  K? unknownValue,
}) {
  if (source == null) {
    throw ArgumentError(
      'A value must be provided. Supported values: '
      '${enumValues.values.join(', ')}',
    );
  }

  return enumValues.entries.singleWhere(
    (e) => e.value == source,
    orElse: () {
      if (unknownValue == null) {
        throw ArgumentError(
          '`$source` is not one of the supported values: '
          '${enumValues.values.join(', ')}',
        );
      }
      return MapEntry(unknownValue, enumValues.values.first);
    },
  ).key;
}

const _$ResearchTypeEnumMap = {
  ResearchType.physics: 0,
  ResearchType.engineering: 1,
  ResearchType.biology: 2,
  ResearchType.social: 3,
  ResearchType.astronomy: 4,
  ResearchType.industry: 5,
  ResearchType.military: 6,
  ResearchType.newWorlds: 7,
};
