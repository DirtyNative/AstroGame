// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'output_resource.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

OutputResource _$OutputResourceFromJson(Map<String, dynamic> json) {
  return OutputResource()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..resourceId = const GuidConverter().fromJson(json['resourceId'] as String)
    ..buildingId = const GuidConverter().fromJson(json['buildingId'] as String)
    ..baseValue = (json['baseValue'] as num).toDouble()
    ..multiplier = (json['multiplier'] as num).toDouble();
}

Map<String, dynamic> _$OutputResourceToJson(OutputResource instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'resourceId': const GuidConverter().toJson(instance.resourceId),
      'buildingId': const GuidConverter().toJson(instance.buildingId),
      'baseValue': instance.baseValue,
      'multiplier': instance.multiplier,
    };
