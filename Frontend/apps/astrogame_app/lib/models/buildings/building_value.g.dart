// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'building_value.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

BuildingValue _$BuildingValueFromJson(Map<String, dynamic> json) {
  return BuildingValue()
    ..buildingId = const GuidConverter().fromJson(json['buildingId'] as String)
    ..level = json['level'] as int
    ..buildingConsumptions = (json['buildingConsumptions'] as List)
        ?.map((e) => e == null
            ? null
            : ResourceAmount.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..buildingProductions = (json['buildingProductions'] as List)
        ?.map((e) => e == null
            ? null
            : ResourceAmount.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..buildingCosts = (json['buildingCosts'] as List)
        ?.map((e) => e == null
            ? null
            : ResourceAmount.fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$BuildingValueToJson(BuildingValue instance) =>
    <String, dynamic>{
      'buildingId': const GuidConverter().toJson(instance.buildingId),
      'level': instance.level,
      'buildingConsumptions': instance.buildingConsumptions,
      'buildingProductions': instance.buildingProductions,
      'buildingCosts': instance.buildingCosts,
    };
