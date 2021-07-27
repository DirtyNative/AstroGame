// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'input_resource.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

InputResource _$InputResourceFromJson(Map<String, dynamic> json) {
  return InputResource()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..resourceId = const GuidConverter().fromJson(json['resourceId'] as String)
    ..buildingId = const GuidConverter().fromJson(json['buildingId'] as String)
    ..baseValue = (json['baseValue'] as num).toDouble()
    ..multiplier = (json['multiplier'] as num).toDouble();
}

Map<String, dynamic> _$InputResourceToJson(InputResource instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'resourceId': const GuidConverter().toJson(instance.resourceId),
      'buildingId': const GuidConverter().toJson(instance.buildingId),
      'baseValue': instance.baseValue,
      'multiplier': instance.multiplier,
    };
