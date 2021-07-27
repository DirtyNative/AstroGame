// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'levelable_building.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

LevelableBuilding _$LevelableBuildingFromJson(Map<String, dynamic> json) {
  return LevelableBuilding()
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
    ..buildingType = _$enumDecode(_$BuildingTypeEnumMap, json['buildingType'])
    ..buildableOn =
        _$enumDecode(_$StellarObjectTypeEnumMap, json['buildableOn'])
    ..inputResources = (json['inputResources'] as List<dynamic>?)
        ?.map((e) => InputResource.fromJson(e as Map<String, dynamic>))
        .toList()
    ..outputResource = (json['outputResource'] as List<dynamic>?)
        ?.map((e) => OutputResource.fromJson(e as Map<String, dynamic>))
        .toList();
}

Map<String, dynamic> _$LevelableBuildingToJson(LevelableBuilding instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'name': instance.name,
      'description': instance.description,
      'assetName': instance.assetName,
      'order': instance.order,
      'neededConditions': instance.neededConditions,
      'conditionFor': instance.conditionFor,
      'technologyCosts': instance.technologyCosts,
      'buildingType': _$BuildingTypeEnumMap[instance.buildingType],
      'buildableOn': _$StellarObjectTypeEnumMap[instance.buildableOn],
      'inputResources': instance.inputResources,
      'outputResource': instance.outputResource,
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

const _$BuildingTypeEnumMap = {
  BuildingType.civilBuilding: 0,
  BuildingType.conveyorBuilding: 1,
  BuildingType.manufacturingFacilityBuilding: 2,
  BuildingType.refineryBuilding: 3,
  BuildingType.researchLaboratoryBuilding: 4,
  BuildingType.storageBuilding: 5,
};

const _$StellarObjectTypeEnumMap = {
  StellarObjectType.star: 0,
  StellarObjectType.blackHole: 1,
  StellarObjectType.planet: 2,
  StellarObjectType.moon: 3,
  StellarObjectType.asteroid: 4,
  StellarObjectType.asteroidBelt: 5,
};
