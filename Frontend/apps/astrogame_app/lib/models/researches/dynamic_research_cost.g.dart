// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'dynamic_research_cost.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

DynamicResearchCost _$DynamicResearchCostFromJson(Map<String, dynamic> json) {
  return DynamicResearchCost()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..resourceId = const GuidConverter().fromJson(json['resourceId'] as String)
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..baseValue = (json['baseValue'] as num)?.toDouble()
    ..multiplier = (json['multiplier'] as num)?.toDouble();
}

Map<String, dynamic> _$DynamicResearchCostToJson(
        DynamicResearchCost instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'resourceId': const GuidConverter().toJson(instance.resourceId),
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'baseValue': instance.baseValue,
      'multiplier': instance.multiplier,
    };
